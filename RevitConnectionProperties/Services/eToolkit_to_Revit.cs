using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Steel;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using System.Collections.ObjectModel;
using Autodesk.AdvanceSteel.CADAccess;
using Autodesk.AdvanceSteel.DocumentManagement;
using Models_SC_Proj;
using System.Windows;
using RvtDwgAddon;
using Autodesk.AdvanceSteel.ConstructionTypes;

namespace RevitConnectionProperties.Services
{
    //[Transaction(TransactionMode.Manual)]
    //[Regeneration(RegenerationOption.Manual)]
    //[Journaling(JournalingMode.NoCommandData)]
    public class eToolkit_to_Revit : IExternalEventHandler
    {
        //Autodesk.Revit.ApplicationServices.Application _app;
        //Autodesk.Revit.DB.Document _doc;

        // The value of the latest request made by the modeless form 
        private RevitRequest m_request = new RevitRequest();

        /// <summary>
        /// A public property to access the current request value
        /// </summary>
        public RevitRequest Request
        {
            get { return m_request; }
        }


        /// <summary>
        /// Excecute the Revit Add-In
        /// </summary>
        public void Execute(UIApplication app)
        {
            //_app = eToolkit_to_Revit_CL._commandData.Application.Application;
            //_doc = eToolkit_to_Revit_CL._commandData.Application.ActiveUIDocument.Document;
            //if (null == _doc)
            //    return;

            double basethk = 150;

            int count1 = 0;
            int paramID = 0;
            try
            {
                foreach (Reference eRef in eToolkit_to_Revit_CL._revit_SelectedConnections)
                {
                    try
                    {
                        //Start detailed steel modeling transaction
                        using (FabricationTransaction trans = new FabricationTransaction(app.ActiveUIDocument.Document, false, "Update connection parameters"))
                        {

                            Element elem = app.ActiveUIDocument.Document.GetElement(eRef.ElementId);
                            if (null == elem || !(elem is StructuralConnectionHandler))
                                return;

                            StructuralConnectionHandler rvtConnection = (StructuralConnectionHandler)elem;

                            FilerObject filerObj = GetFilerObject(app.ActiveUIDocument.Document, eRef);

                            if (null == filerObj || !(filerObj is UserAutoConstructionObject))
                                return;

                            UserAutoConstructionObject asConnection = (UserAutoConstructionObject)filerObj;
                            //
                            //read connection parameters
                            IFiler connectionFiler = asConnection.Save();

                            if (connectionFiler != null)
                            {
                                //I choose to modify thickess of the base plate
                                connectionFiler.WriteItem(Convert.ToDouble(250.0), BasePlate.BaseThickness); //units must be milimmeters;

                                asConnection.Load(connectionFiler); //update connection parameters
                                asConnection.Update();

                                connectionFiler.WriteItem(Convert.ToDouble(1050.0), BasePlate.BaseWidth); //units must be milimmeters;


                                asConnection.Load(connectionFiler); //update connection parameters
                                asConnection.Update();


                                connectionFiler.WriteItem(Convert.ToDouble(150.0), MomentConnection_Rvt.EndPlateThickness); //units must be milimmeters;

                                connectionFiler.WriteItem(Convert.ToDouble(550.0), MomentConnection_Rvt.EndPlateWidth); //units must be milimmeters;

                                connectionFiler.WriteItem(Convert.ToDouble(1550.0), BasePlate.BaseLength); //units must be milimmeters;

                                asConnection.Load(connectionFiler); //update connection parameters

                                asConnection.Update();
                                //
                                //if the connection parameters are modified, than we have to set this flag to true, meaning that this connection has different parameters than it's connection type.
                                //rvtConnection.OverrideTypeParams = true;

                            }
                            trans.Commit();
                        }
                    }
                    catch (Autodesk.Revit.Exceptions.OperationCanceledException)
                    {
                        return;
                    }
                }

                //_doc.Save();
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return;
            }

            MessageBox.Show("Saved!","Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
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

        public string GetName()
        {
            return "R2020 External Event Sample";
        }
    }

    public class eToolkit_to_Revit_CL
    {
        public static ObservableCollection<ObservableCollection<Parameter_Items>> _theseParameters;
        public static IList<Reference> _revit_SelectedConnections;

        public eToolkit_to_Revit_CL(ObservableCollection<ObservableCollection<Parameter_Items>> ParametersMasterList, IList<Reference> Revit_SelectedConnections)
        {
            _theseParameters = ParametersMasterList;
            _revit_SelectedConnections = Revit_SelectedConnections;
        }
        
    }
}
