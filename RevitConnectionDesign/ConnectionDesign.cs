using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Steel;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using eToolkit_View.ViewModels;
using RevitConnectionProperties.Services;
using Models_SC_Proj;
using RvtDwgAddon;
using Autodesk.AdvanceSteel.CADAccess;
using Autodesk.AdvanceSteel.ConstructionTypes;
using Autodesk.AdvanceSteel.DocumentManagement;
using Models_SC_Proj.Model;
using RevitConnectionProperties.Const;

namespace RevitConnectionDesign
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]
    public class ConnectionDesign : IExternalCommand
    {
        Autodesk.Revit.ApplicationServices.Application _app;
        Autodesk.Revit.DB.Document _doc;

        /// <summary>
        /// Excecute the Revit Add-In
        /// </summary>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Localise the Revit application and document
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            _app = uiApp.Application;
            _doc = uiDoc.Document;
            if (null == _doc)
                return Result.Failed;

            //Initialises the primary ViewModel
            ViewModel Cache_VM = new ViewModel();

            //A new handler to handle request posting by the dialog
            eToolkit_to_Revit handler = new eToolkit_to_Revit();

            //External Event for the dialog to use (to post requests)
            ExternalEvent exEvent = ExternalEvent.Create(handler);

            Cache_VM.exEvent = exEvent;
            Cache_VM.handler = handler;
            
            //Initialises a list of Revit connections
            ObservableCollection<Connection_SC> ConnectionList = new ObservableCollection<Connection_SC>();

            //Initialises a list of Revit connections
            //ObservableCollection<ParentConnection> ParentConnectionList = new ObservableCollection<ParentConnection>();

            //ParentConnectionList.Add(new ParentConnection { ElementID = ConnectionType.BasePlate.ToString(), ConnectionType = RvtConnectionType.BasePlateConnection, Include_Connection = true, ChildConnection =new ObservableCollection<Connection_SC>() });
            //ParentConnectionList.Add(new ParentConnection { ElementID = ConnectionType.MomentConnection.ToString(), ConnectionType = RvtConnectionType.MomentConnection, Include_Connection = true, ChildConnection = new ObservableCollection<Connection_SC>() });
            //ParentConnectionList.Add(new ParentConnection { ElementID = ConnectionType.SimpleConnection.ToString(), ConnectionType = RvtConnectionType.SimpleConnection, Include_Connection = true, ChildConnection = new ObservableCollection<Connection_SC>() });


            ObservableCollection<Connection_SC> BasePlates = new ObservableCollection<Connection_SC>();

            ObservableCollection<Connection_SC> MomentConnections = new ObservableCollection<Connection_SC> ();

            ObservableCollection<Connection_SC> SimpleConnections = new ObservableCollection<Connection_SC> ();


            //Initialises a list of parameter items for each connections
            ObservableCollection<ObservableCollection<Parameter_Items>> ParametersMasterList = new ObservableCollection<ObservableCollection<Parameter_Items>>();

            //Initialises a collection of Load Combinations for each Revit connection
            ObservableCollection<ObservableCollection<LoadCombinationItem>> LoadCombinations_Imported_MasterList = new ObservableCollection<ObservableCollection<LoadCombinationItem>>();
            
            int count1 = 0;
            int paramID = 0;
            
            try
            {
                // Create a filter for structural connections.
                LogicalOrFilter types = new LogicalOrFilter(new List<ElementFilter> { new ElementCategoryFilter(BuiltInCategory.OST_StructConnections) });
                StructuralConnectionSelectionFilter filter = new StructuralConnectionSelectionFilter(types);

                //Returns a list of all selected elements by the user
                IList<Reference> SelectedElements = uiDoc.Selection.PickObjects(ObjectType.Element, filter, "Select connections to design");

                foreach (Reference eRef in SelectedElements)
                {
                    using (FabricationTransaction trans = new FabricationTransaction(_doc, false, "Update connection parameters", true))
                    {
                        //This collection is local to this class and used to populate the master list of Revit connection parameters
                        ObservableCollection<Parameter_Items> tempparameters = new ObservableCollection<Parameter_Items>();

                        //This is the set of Revit parameters read from model
                        Dictionary<string, object> ParameterItem = new Dictionary<string, object>();

                        //Filer Object allows the api to read or edit objects in Revit model
                        FilerObject filerObj = GetFilerObject(_doc, eRef);

                        if (null == filerObj || !(filerObj is UserAutoConstructionObject))
                            continue;

                        UserAutoConstructionObject asConnection = (UserAutoConstructionObject)filerObj;

                        //Read or write connection parameters using IFiler
                        IFiler connectionFiler = asConnection.Save();

                        if (connectionFiler != null)
                        {
                            ParameterItem = connectionFiler.GetItems();

                            foreach (var item in ParameterItem)
                            {
                                tempparameters.Add(new Parameter_Items { Description = item.Key, Value = item.Value.ToString() });
                            }
                        }
                        
                        string primaryID = "";
                        string secondaryIDs = "";
                        int count = 0;

                        //Element is used to find parent elements
                        Element elem = _doc.GetElement(eRef.ElementId);

                        //Allows the loop to perform further actions if the element is a structural connection
                        if (null == elem || !(elem is StructuralConnectionHandler))
                            continue;

                        foreach (ElementId ParentElement_ID in GetParentIDs(elem))
                        {
                            Element ParentElement = uiDoc.Document.GetElement(ParentElement_ID);
                            
                            if (count == 0)
                            {
                                primaryID = ParentElement.Name;
                            }
                            else
                            {
                                secondaryIDs = ParentElement.Name + "  ";
                            }
                            count++;
                            count1++;
                        }


                        if (elem.Name == RvtConnectionType.BasePlateConnection)
                        {
                            BasePlates.Add(AddConnection(elem, primaryID, secondaryIDs, paramID));
                        }
                        else if (elem.Name == RvtConnectionType.MomentConnection)
                        {
                            MomentConnections.Add(AddConnection(elem, primaryID, secondaryIDs, paramID));
                        }
                        else if (elem.Name == RvtConnectionType.SimpleConnection)
                        {
                            SimpleConnections.Add(AddConnection(elem, primaryID, secondaryIDs, paramID));
                        }


                        StructuralConnectionHandler rvtConnection = (StructuralConnectionHandler)elem; 

                        ConnectionList.Add(new Connection_SC
                        {
                            Include_Connection = true,
                            ElementID = elem.Id.ToString(),
                            PrimaryElement = primaryID,
                            SecondaryElement = secondaryIDs,
                            ConnectionType = elem.Name,
                            ConnectionCapacity = "0.9",
                            ConnectionCost = "R 1 230,00",
                            ParameterID = paramID,
                            PeakLC = "1",
                            ULS_Fr = "40",
                            ULS_Mr = "60",
                            ULS_Vr = "120",
                            ULS_Fu_Fr = "0.6",
                            ULS_Mu_Mr = "0.9",
                            ULS_Vu_Vr = "0.8",
                            SiblingID = rvtConnection.GroupId.ToString()
                        }); ;

                        ParametersMasterList.Add(tempparameters);
                        paramID++;
                    }
                }

                eToolkit_to_Revit_CL updateRevit3DModel_CL = new eToolkit_to_Revit_CL(ParametersMasterList, SelectedElements);

            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }

            Cache_VM.ConnectionList = ConnectionList;
            //Cache_VM.ParentConnectionList = ParentConnectionList;

            Cache_VM.BasePlates = BasePlates;
            Cache_VM.SimpleConnections = SimpleConnections;
            Cache_VM.MomentConnections = MomentConnections;

            if (ParametersMasterList.Count > 0)
                Cache_VM.Parameters = ParametersMasterList[0];

            Cache_VM.ParametersMasterList = ParametersMasterList;
            Cache_VM.LoadCombinationMasterList = LoadCombinations_Imported_MasterList;
            //Cache_VM.ConnectionType = "Haunch Connection";
                                 
            try
            {
                App.thisApp.ShowForm(Cache_VM);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

        }


        /// <summary>
        /// Identify the type of the ParentElement_ID known to the UI.
        /// </summary>
        public IList<ElementId> GetParentIDs(Element e)
        {
            // An instance of a system family has a designated class.
            // You can use it identify the type of ParentElement_ID.
            // e.g., walls, floors, roofs.

            //string s = "";
            IList<ElementId> ParentIDs = null;

            if (e is StructuralConnectionHandler)
            {
                StructuralConnectionHandler thisSChandler = (StructuralConnectionHandler)e;

                ParentIDs = thisSChandler.GetConnectedElementIds();
                //foreach (var item in ParentIDs)
                //{
                //    s = item.IntegerValue.ToString()+" " + s + " ";
                //}
            }

            return ParentIDs;
        }


        /// <summary>
        /// Function that returns the AS Filer Object from the selected reference object
        /// </summary>
        public static FilerObject GetFilerObject(Autodesk.Revit.DB.Document doc, Reference eRef)
        {
            FilerObject filerObject = null;
            Autodesk.AdvanceSteel.DocumentManagement.Document curDocAS = DocumentManager.GetCurrentDocument();
            if (null != curDocAS)
            {
                OpenDatabase currentDatabase = curDocAS.CurrentDatabase;
                if (null != currentDatabase)
                {
                    Guid uid = SteelElementProperties.GetFabricationUniqueID(doc, eRef);
                    string asHandle = currentDatabase.getUidDictionary().GetHandle(uid);
                    filerObject = FilerObject.GetFilerObjectByHandle(asHandle);
                }
            }
            return filerObject;
        }

        public Connection_SC AddConnection(Element elem, string primaryID, string secondaryIDs, int paramID)
        {
            return new Connection_SC
            {
                Include_Connection = true,
                ElementID = elem.Id.ToString(),
                PrimaryElement = primaryID,
                SecondaryElement = secondaryIDs,
                ConnectionType = elem.Name,
                ConnectionCapacity = "0.9",
                ConnectionCost = "R 1 230,00",
                ParameterID = paramID,
                PeakLC = "1",
                ULS_Fr = "40",
                ULS_Mr = "60",
                ULS_Vr = "120",
                ULS_Fu_Fr = "0.6",
                ULS_Mu_Mr = "0.9",
                ULS_Vu_Vr = "0.8"
            };
        }
    }
}
