using eToolKit_Classes;
using eToolkit_View.Views;
using eToolkit_View.Interface;
using eToolkit_View.Services;
using Models_SC_Proj;
using Models_SC_Proj.Commands;
using Prism.Mvvm;
using Revit_eToolKit_Map;
using Revit_eToolKit_Map.Mappers;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Input;
using RevitConnectionProperties.Services;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Models_SC_Proj.Model;

namespace eToolkit_View.ViewModels
{
    public class ViewModel : ViewModelBase, IViewModel
    {
        #region Master Properties
        /// <summary>
        /// This is a collection of all the 3rd party connections selected by the user
        /// </summary>
        private ObservableCollection<Connection_SC> _ConnectionList;
        public ObservableCollection<Connection_SC> ConnectionList { get { return _ConnectionList; } set { _ConnectionList = value; OnPropertyChanged(); } }

        /// <summary>
        /// This is a collection of all the 3rd party connections selected by the user
        /// </summary>
        private ObservableCollection<ParentConnection> _ParentConnectionList;
        public ObservableCollection<ParentConnection> ParentConnectionList { get { return _ParentConnectionList; } set { _ParentConnectionList = value; OnPropertyChanged(); } }

        /// <summary>
        /// This is a property of all the 3rd party base plate connections
        /// </summary>
        private ObservableCollection<Connection_SC> _BasePlates;
        public ObservableCollection<Connection_SC> BasePlates { get { return _BasePlates; } set { _BasePlates = value; OnPropertyChanged(); } }

        /// <summary>
        /// This is a property of all the 3rd party moment connections
        /// </summary>
        private ObservableCollection<Connection_SC> _MomentConnections;
        public ObservableCollection<Connection_SC> MomentConnections { get { return _MomentConnections; } set { _MomentConnections = value; OnPropertyChanged(); } }

        /// <summary>
        /// This is a property of all the 3rd party simple connections
        /// </summary>
        private ObservableCollection<Connection_SC> _SimpleConnections;
        public ObservableCollection<Connection_SC> SimpleConnections { get { return _SimpleConnections; } set { _SimpleConnections = value; OnPropertyChanged(); } }


        /// <summary>
        /// This is a collection of an instance of the 3rd party connection parameters
        /// </summary>
        private ObservableCollection<Parameter_Items> _Parameters;
        public ObservableCollection<Parameter_Items> Parameters { get { return _Parameters; } set { _Parameters = value; OnPropertyChanged(); } }


        /// <summary>
        /// This is a collection of an instance of the 3rd party connection load combinations
        /// </summary>
        private ObservableCollection<LoadCombinationItem> _LoadCombinations;
        public ObservableCollection<LoadCombinationItem> LoadCombinations { get { return _LoadCombinations; } set { _LoadCombinations = value; OnPropertyChanged(); } }


        /// <summary>
        /// This is a collection of all of the 3rd party connection parameters
        /// </summary>
        private ObservableCollection<ObservableCollection<Parameter_Items>> _parametersMasterList;
        public ObservableCollection<ObservableCollection<Parameter_Items>> ParametersMasterList { get { return _parametersMasterList; } set { _parametersMasterList = value; } }

        /// <summary>
        /// This is a collection of all of the 3rd party connection load combinations
        /// </summary>
        private ObservableCollection<ObservableCollection<LoadCombinationItem>> _LoadCombinationMasterList;
        public ObservableCollection<ObservableCollection<LoadCombinationItem>> LoadCombinationMasterList { get { return _LoadCombinationMasterList; } set { _LoadCombinationMasterList = value; } }

        /// <summary>
        /// This is a collection of all of the 3rd party connection Selected elements
        /// </summary>
        private IList<Reference> _Revit_SelectedConnections;
        public IList<Reference> SelectedElements { get { return _Revit_SelectedConnections; } set { _Revit_SelectedConnections = value; } }

        /// <summary>
        /// This is the dynamic 2D drawing of the designed connection
        /// </summary>
        private Bitmap _Connection_2D;
        public Bitmap Connection_2D { get { return _Connection_2D; } set { _Connection_2D = value; OnPropertyChanged(); } }

        /// <summary>
        /// This is a collection of the 3rd party connection properties mapped to local properties
        /// </summary>
        private ObservableCollection<Parameter_Items> _Mapped_eToolKit_Parameters;
        public ObservableCollection<Parameter_Items> Mapped_eToolKit_Parameters { get { return _Mapped_eToolKit_Parameters; } set { _Mapped_eToolKit_Parameters = value; OnPropertyChanged(); } }
        #endregion
        
        #region Commands
        /// <summary>
        /// This command allows the user to copy all items of the object to the clipboard
        /// </summary>
        private RelayCommand<ObservableCollection<Parameter_Items>> _cmdCopyClick;
        public ICommand CmdCopyClick
        {
            get
            {
                if (_cmdCopyClick == null)
                {
                    _cmdCopyClick = new RelayCommand<ObservableCollection<Parameter_Items>>(new Action<ObservableCollection<Parameter_Items>>(ViewModelService.CopyClick));
                }
                return _cmdCopyClick;
            }
        }


        /// <summary>
        /// This command loads the selected 3rd party connection into the local MVVM and solvers etc.
        /// </summary>
        private RelayCommand<object> _cmdPropertiesClick;
        public ICommand CmdPropertiesClick { get { if (_cmdPropertiesClick == null) _cmdPropertiesClick = new RelayCommand<object>(new Action<object>(MapActivatedConnection)); return _cmdPropertiesClick; } }


        /// <summary>
        /// 
        /// </summary>
        private RelayCommand<object> _CmdParameterChanged;
        public ICommand CmdParameterChanged { get { if (_CmdParameterChanged == null) _CmdParameterChanged = new RelayCommand<object>(new Action<object>(UpdateCalculator)); return _CmdParameterChanged; } }

        /// <summary>
        /// This command updates the calculated into the 3D model
        /// </summary>
        private RelayCommand<object> _cmdUpdate3D;
        public ICommand CmdUpdate3D { get { if (_cmdUpdate3D == null) _cmdUpdate3D = new RelayCommand<object>(new Action<object>(Update3DModel)); return _cmdUpdate3D; } }

        #endregion

        #region Methods
        int i = 0;
        private void UpdateCalculator(object item)
        {
            foreach (var items in _ConnectionList)
            {
                if (items.ParameterID == SelectedConnection.ParameterID)
                {
                    i++;
                    items.PeakLC = i.ToString();

                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Connection_SC SelectedConnection = new Connection_SC();
        private void MapActivatedConnection(object item)
        {
            SelectedConnection = item as Connection_SC;
            if (SelectedConnection == null) return;

            ObservableCollection<Parameter_Items> OriginalParameterList = ParametersMasterList[SelectedConnection.ParameterID];

            switch (ConnectionType_Mapper.Map_Revit_to_eToolKit_ConnectionType(SelectedConnection.ConnectionType))
            {
                case ConnectionType.MomentConnection:
                    CurrentMomentConnection = Revit_to_eToolKit.Map_Revit_to_eToolKit_MomentConnection(OriginalParameterList);
                    //_generalConnection.BoltDiameter = "M" + CurrentMomentConnection.Bolts_Diameter.ToString();

                    ActivatedConnection_to_VM_Properties(CurrentMomentConnection);

                    ConnectionName = "Moment Connection";
                    break;
                case ConnectionType.SimpleConnection:
                    ConnectionName = "Simple Connection";
                    break;
                case ConnectionType.BasePlate:
                    ConnectionName = "Base Plate Connection";
                    break;
                case ConnectionType.None:
                    ConnectionName = "Unknown Connection";

                    break;
            }


            //this.Parameters = MappedParameterList;
            //this.LoadCombinations = LoadCombinationMasterList[SelectedConnection.ParameterID];
        }


        public ExternalEvent exEvent { get; set; }
        public eToolkit_to_Revit handler { get; set; }
        /// <summary>
        /// Updates 3D model
        /// </summary>
        /// <param name="item"></param>
        private void Update3DModel(object item)
        {
            handler.Request.Make(RequestId.MakeLeft);
            exEvent.Raise();
        }

        private void DrawingMain()
        {

            //Clear PictureBox1
            Bitmap bmp = new Bitmap(400, 400);

            Graphics gfx = Graphics.FromImage(bmp);
            Pen myPen = new Pen(System.Drawing.Color.Red);

            gfx.DrawRectangle(myPen, 0, 0, 100, 100);

            this.Connection_2D = bmp;


            #region MyRegion

            //PictureBox1.Image = bmp
            //gfx = Graphics.FromImage(bmp)


            //            'Initiate Plate Properties
            //            Dims.T_Plt = CSng(TP_txt.Text)
            //            Dims.D_Plt = CSng(DP_txt.Text)
            //            Dims.B_Plt = CSng(BP_txt.Text)
            //            Dims.G_Plt = CSng(GP_txt.Text)
            //            Dims.P_Plt = CSng(PP_txt.Text)




            //            'Dim f As New System.Drawing.Font("Microsoft Sans Serif", 8.25)

            //            'Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Red)
            //            'Dim formGraphics As System.Drawing.Graphics
            //            'formGraphics = PictureBox1.CreateGraphics()
            //            'formGraphics.DrawLine(myPen, 10, 10, 250, 190)

            //            'PictureBox1.CreateGraphics.DrawString("gjfktfiydkytfd", f, Brushes.Black, 20, 20)
            //            'PictureBox1.CreateGraphics.DrawLine(Pens.MediumVioletRed, 10, 10, 240, 180)

            //            'myPen.Dispose()
            //            'formGraphics.Dispose()



            //            'Reduction Scale Factor
            //            Dim Fact As Single
            //            If CheckBox3.Checked = False Then
            //                If Dims.D_Plt >= Dims.B_Plt Then
            //                    Fact = 220 / Dims.D_Plt
            //                Else
            //                    Fact = 220 / Dims.B_Plt
            //                End If
            //            ElseIf CheckBox3.Checked = True Then
            //                If Dims.D_Plt >= Dims.B_Plt Then
            //                    Fact = 175 / Dims.D_Plt
            //                Else
            //                    Fact = 175 / Dims.B_Plt
            //                End If
            //            End If

            //            'Diameter of bolt
            //            DboltValue()
            //            Dims.DBolt = Dims.DBolt * Fact


            //            'Factored Section dimentions
            //            Dim secH As Single = Dims.h * Fact
            //            Dim SecB As Single = Dims.b * Fact
            //            Dim FlanT As Single = Dims.tf * Fact
            //            Dim WebT As Single = Dims.tw * Fact
            //            Dim WebH As Single = (Dims.h - 2 * Dims.tf) * Fact
            //            Dim BoltG As Single = Dims.G_Plt * Fact
            //            Dim BoltP As Single = Dims.P_Plt * Fact
            //            Dim BoltD As Single = Dims.DBolt

            //            'Global Base Plate Dimensions
            //            Dim Pltx As Single = Dims.B_Plt * Fact
            //            Dim Plty As Single = Dims.D_Plt * Fact


            //            'Centre Point Dimentions
            //            Dim posx_CP As Single
            //            Dim posy_CP As Single
            //            If combinedplate_chk.Checked = False Then
            //                posx_CP = 130
            //                posy_CP = 130
            //            ElseIf combinedplate_chk.Checked = True Then
            //                posx_CP = 140
            //                posy_CP = 140
            //            End If



            //            'Base plate reference point 1
            //            Dim pos1x As Single = posx_CP - Pltx / 2
            //            Dim pos1y As Single = posy_CP - Plty / 2


            //            'Draw Base Plate
            //            gfx.DrawRectangle(Pens.Black, pos1x, pos1y, Pltx, Plty)



            //            'Draw Section
            //            If Dims.SecNum = 1 Or Dims.SecNum = 2 Then         'Universal Beam and Column
            //                'Flanges
            //                gfx.DrawRectangle(Pens.Black, pos1x + (Pltx - SecB) / 2, pos1y + (Plty - secH) / 2, SecB, FlanT)
            //                gfx.DrawRectangle(Pens.Black, pos1x + (Pltx - SecB) / 2, pos1y + (Plty - (Plty - secH) / 2) - FlanT, SecB, FlanT)

            //                'Web
            //                gfx.DrawRectangle(Pens.Black, pos1x + Pltx / 2 - WebT / 2, pos1y + Plty / 2 - WebH / 2, WebT, WebH)

            //                'Bolt Holes
            //                If Dims.h< 165.1 Then
            //                    gfx.DrawEllipse(Pens.Black, pos1x + Pltx / 2 - BoltG / 2 - Dims.DBolt / 2, pos1y + Plty / 2 - Dims.DBolt / 2, Dims.DBolt, Dims.DBolt)
            //                    gfx.DrawEllipse(Pens.Black, pos1x + Pltx / 2 + BoltG / 2 - Dims.DBolt / 2, pos1y + Plty / 2 - Dims.DBolt / 2, Dims.DBolt, Dims.DBolt)
            //                Else
            //                    gfx.DrawEllipse(Pens.Black, pos1x + Pltx / 2 - BoltG / 2 - Dims.DBolt / 2, pos1y + Plty / 2 - BoltP / 2 - Dims.DBolt / 2, Dims.DBolt, Dims.DBolt)
            //                    gfx.DrawEllipse(Pens.Black, pos1x + Pltx / 2 + BoltG / 2 - Dims.DBolt / 2, pos1y + Plty / 2 - BoltP / 2 - Dims.DBolt / 2, Dims.DBolt, Dims.DBolt)
            //                    gfx.DrawEllipse(Pens.Black, pos1x + Pltx / 2 - BoltG / 2 - Dims.DBolt / 2, pos1y + Plty / 2 + BoltP / 2 - Dims.DBolt / 2, Dims.DBolt, Dims.DBolt)
            //                    gfx.DrawEllipse(Pens.Black, pos1x + Pltx / 2 + BoltG / 2 - Dims.DBolt / 2, pos1y + Plty / 2 + BoltP / 2 - Dims.DBolt / 2, Dims.DBolt, Dims.DBolt)
            //                End If
            //            End If




            //            '
            //            '
            //            '
            //            'Dimensioning
            //            If Dims.includedims = 1 Then

            //                'Position Lines of P and G
            //                Dim myPen1 As New System.Drawing.Pen(System.Drawing.Color.Red)
            //                With myPen1
            //                    .DashStyle = Drawing2D.DashStyle.DashDot
            //                End With

            //                'Position Lines of Plate
            //                Dim myPen2 As New System.Drawing.Pen(System.Drawing.Color.Blue)
            //                With myPen2
            //                    .DashStyle = Drawing2D.DashStyle.DashDot
            //                End With

            //                '"Dimension font"
            //                Dim f As New System.Drawing.Font("CG Omega", 9, FontStyle.Regular)

            //                'Breadth B
            //                gfx.DrawLine(myPen2, pos1x, pos1y - 5, pos1x, pos1y - 35)
            //                gfx.DrawLine(myPen2, pos1x + Pltx, pos1y - 5, pos1x + Pltx, pos1y - 35)
            //                gfx.DrawLine(myPen2, pos1x, pos1y - 30, pos1x + Pltx / 2 - 7, pos1y - 30)
            //                gfx.DrawLine(myPen2, pos1x + Pltx, pos1y - 30, pos1x + Pltx / 2 + 7, pos1y - 30)

            //                'B - Text
            //                gfx.DrawString("B", f, Brushes.Black, pos1x + Pltx / 2 - 5, pos1y - 38)

            //                'Skip G
            //                If(Dims.SecNum = 3 And Dims.h >= 155) Then
            //                   GoTo GType2
            //               ElseIf(Dims.SecNum = 4 And Dims.h >= 105) Then
            //                  GoTo GType2
            //              End If

            //                'Bolt Spacing G
            //                gfx.DrawLine(myPen1, pos1x + Pltx / 2 - BoltG / 2, pos1y + Plty / 2 - BoltP / 2 - 5 - Dims.DBolt / 2 _
            //                             , pos1x + Pltx / 2 - BoltG / 2, pos1y - 20)
            //                gfx.DrawLine(myPen1, pos1x + Pltx / 2 + BoltG / 2, pos1y + Plty / 2 - BoltP / 2 - 5 - Dims.DBolt / 2, _
            //                             pos1x + Pltx / 2 + BoltG / 2, pos1y - 20)
            //                gfx.DrawLine(myPen1, pos1x + Pltx / 2 - BoltG / 2, pos1y - 15, pos1x + Pltx / 2 - 7, pos1y - 15)
            //                gfx.DrawLine(myPen1, pos1x + Pltx / 2 + BoltG / 2, pos1y - 15, pos1x + Pltx / 2 + 7, pos1y - 15)

            //                'G - Text
            //                gfx.DrawString("G", f, Brushes.Black, pos1x + Pltx / 2 - 6, pos1y - 23)

            //                GoTo SkipGType2

            //GType2:
            //                'Bolt Spacing G2
            //                gfx.DrawLine(myPen1, pos1x + BoltG, pos1y + Plty / 2 - BoltP / 2 - 5 - Dims.DBolt / 2, pos1x + BoltG, _
            //                             pos1y - 20)
            //                gfx.DrawLine(myPen1, pos1x, pos1y - 15, pos1x + BoltG / 2 - 7, pos1y - 15)
            //                gfx.DrawLine(myPen1, pos1x + BoltG, pos1y - 15, pos1x + BoltG / 2 + 7, pos1y - 15)

            //                'G - Text
            //                gfx.DrawString("G", f, Brushes.Black, pos1x + BoltG / 2 - 6, pos1y - 23)

            //SkipGType2:


            //                'Depth D
            //                gfx.DrawLine(myPen2, pos1x - 5, pos1y, pos1x - 40, pos1y)
            //                gfx.DrawLine(myPen2, pos1x - 5, pos1y + Plty, pos1x - 40, pos1y + Plty)
            //                gfx.DrawLine(myPen2, pos1x - 35, pos1y, pos1x - 35, pos1y + Plty / 2 - 8)
            //                gfx.DrawLine(myPen2, pos1x - 35, pos1y + Plty, pos1x - 35, pos1y + Plty / 2 + 8)

            //                'D - Text
            //                gfx.DrawString("D", f, Brushes.Black, pos1x - 41, pos1y + Plty / 2 - 7)

            //                'Skip P
            //                If(Dims.SecNum = 1 Or Dims.SecNum = 2 Or Dims.SecNum = 4) And Dims.h< 165 Then
            //                    GoTo EndPType2
            //                ElseIf (Dims.SecNum = 3 And Dims.h< 105) Then
            //                   GoTo EndPType2
            //               ElseIf Dims.SecNum = 5 Or Dims.SecNum = 6 Then
            //                   GoTo EndPType2
            //               ElseIf Dims.SecNum = 7 Or Dims.SecNum = 8 Or (Dims.SecNum = 9 And Dims.h< 105) Then
            //                  GoTo EndPType2
            //              End If

            //                'Skip P type 1
            //                If(Dims.SecNum = 3 And Dims.h >= 155) Then
            //                   GoTo SkipP
            //               ElseIf(Dims.SecNum = 4 And Dims.h >= 105) Then
            //                  GoTo SkipP
            //              End If

            //                'Bolt Spacing P
            //                gfx.DrawLine(myPen1, pos1x + Pltx / 2 - BoltG / 2 - BoltD / 2 - 8, pos1y + Plty / 2 - BoltP / 2, _
            //                             pos1x - 20, pos1y + Plty / 2 - BoltP / 2)
            //                gfx.DrawLine(myPen1, pos1x + Pltx / 2 - BoltG / 2 - BoltD / 2 - 8, pos1y + Plty / 2 + BoltP / 2, _
            //                             pos1x - 20, pos1y + Plty / 2 + BoltP / 2)
            //                gfx.DrawLine(myPen1, pos1x - 15, pos1y + Plty / 2 - BoltP / 2, pos1x - 15, pos1y + Plty / 2 - 8)
            //                gfx.DrawLine(myPen1, pos1x - 15, pos1y + Plty / 2 + BoltP / 2, pos1x - 15, pos1y + Plty / 2 + 8)

            //                'P - Text
            //                gfx.DrawString("P", f, Brushes.Black, pos1x - 20, pos1y + Plty / 2 - 7)

            //                GoTo EndPType2

            //SkipP:

            //                'Bolt Spacing P2
            //                gfx.DrawLine(myPen1, pos1x + BoltG - BoltD / 2 - 11, pos1y + Plty / 2 - BoltP / 2, pos1x - 23, _
            //                             pos1y + Plty / 2 - BoltP / 2)
            //                gfx.DrawLine(myPen1, pos1x + BoltG - BoltD / 2 - 11, pos1y + Plty / 2 + BoltP / 2, pos1x - 23, _
            //                             pos1y + Plty / 2 + BoltP / 2)
            //                gfx.DrawLine(myPen1, pos1x - 18, pos1y + Plty / 2 - BoltP / 2, pos1x - 18, pos1y + Plty / 2 - 8)
            //                gfx.DrawLine(myPen1, pos1x - 18, pos1y + Plty / 2 + BoltP / 2, pos1x - 18, pos1y + Plty / 2 + 8)

            //                'P - Text
            //                gfx.DrawString("P", f, Brushes.Black, pos1x - 20, pos1y + Plty / 2 - 7)

            //EndPType2:
            //            End If

            //            'Set LineDDim = ActiveSheet
            //            'With LineDDim.Shapes.AddLine(pos1x + Pltx / 2, pos1y - 15, pos1x + Pltx / 2, pos1y + Plty + 15).Line
            //            '.Weight = 1#
            //            '.DashStyle = msoLineDashDot
            //            '.ForeColor.RGB = RGB(0, 0, 0)
            //            'End With

            //            PictureBox1.Image = bmp
            //            PictureBox1.DrawToBitmap(bmp, New System.Drawing.Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height))

            //            Dims.picturelocation = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "picture.bmp")
            //            bmp.Save(Dims.picturelocation, System.Drawing.Imaging.ImageFormat.Bmp)

            //        Catch ex As Exception
            //            MessageBox.Show(ex.Message)

            //        End Try 
            #endregion
        }

        private void Launch_eToolkit()
        {


        }

        //Property Update commands
        private void ActivatedConnection_to_VM_Properties(MomentConnection CurrentConnection)
        {
            BoltDiameter = CurrentConnection.Bolts_Diameter.ToString();
            EndPlateThickness = CurrentConnection.Plate_EndorFin_Thickness.ToString();
            EndPlateWidth = CurrentConnection.Plate_EndorFin_Width.ToString();
            EndPlateLength = CurrentConnection.Plate_EndorFin_Height.ToString();
        }

        public MomentConnection CurrentMomentConnection { get; set; }
        #endregion

        #region Object Viewer

        //private System.Drawing.Size _objectView_size;
        //public System.Drawing.Size objectView_size
        //{
        //    get { return _objectView_size; }
        //    set
        //    {
        //        _objectView_size = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private UIDocument _uiDoc;
        //public UIDocument uiDoc
        //{
        //    get { return _uiDoc; }
        //    set
        //    {
        //        _uiDoc = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private Options _options;
        //public Options Options
        //{
        //    get { return _options; }
        //    set
        //    {
        //        _options = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private ICommand hiButtonCommand;
        //private ICommand toggleExecuteCommand { get; set; }
        //private bool canExecute = true;
        //public bool CanExecute
        //{
        //    get
        //    {
        //        return this.canExecute;
        //    }

        //    set
        //    {
        //        if (this.canExecute == value)
        //        {
        //            return;
        //        }
        //        this.canExecute = value;
        //    }
        //}

        #endregion

        //General connection VM
        #region General Connection

        #region GC UC Properties
        public string _ConnectionName = "Connection 1";
        public string ConnectionName { get { return _ConnectionName; } set { _ConnectionName = value; OnPropertyChanged(); } }


        public bool _EndPlate_UC_Visibility = true;
        public bool EndPlate_UC_Visibility { get { return _EndPlate_UC_Visibility; } set { _EndPlate_UC_Visibility = value; OnPropertyChanged(); } }

        public bool _Haunch_UC_Visibility = false;
        public bool Haunch_UC_Visibility { get { return _Haunch_UC_Visibility; } set { _Haunch_UC_Visibility = value; OnPropertyChanged(); } }


        public bool _BoltDetails_UC_Visibility = false;
        public bool BoltDetails_UC_Visibility { get { return _BoltDetails_UC_Visibility; } set { _BoltDetails_UC_Visibility = value; OnPropertyChanged(); } }

        public bool _BoltGroup_UC_Visibility = false;
        public bool BoltGroup_UC_Visibility { get { return _BoltGroup_UC_Visibility; } set { _BoltGroup_UC_Visibility = value; OnPropertyChanged(); } }

        public bool _Stiffeners_UC_Visibility = false;
        public bool Stiffeners_UC_Visibility { get { return _Stiffeners_UC_Visibility; } set { _Stiffeners_UC_Visibility = value; OnPropertyChanged(); } }
        #endregion

        #region GC Connection Properties
        public string _BoltType;
        public string BoltType { get { return _BoltType; } set { _BoltType = value; OnPropertyChanged(); } }

        public string _BoltGrade;
        public string BoltGrade { get { return _BoltGrade; } set { _BoltGrade = value; OnPropertyChanged(); } }

        public string _BoltDiameter;
        public string BoltDiameter { get { return _BoltDiameter; } set { _BoltDiameter = value; OnPropertyChanged(); } }

        public string _BoltGaugeHorizontalDistance;
        public string BoltGaugeHorizontalDistance { get { return _BoltGaugeHorizontalDistance; } set { _BoltGaugeHorizontalDistance = value; OnPropertyChanged(); } }

        public string _BoltGaugeNumberPerSide;
        public string BoltGaugeNumberPerSide { get { return _BoltGaugeNumberPerSide; } set { _BoltGaugeNumberPerSide = value; OnPropertyChanged(); } }

        public string _BoltIntermediateDistance;
        public string BoltIntermediateDistance { get { return _BoltIntermediateDistance; } set { _BoltIntermediateDistance = value; OnPropertyChanged(); } }


        public string _StandardWelds;
        public string StandardWelds { get { return _StandardWelds; } set { _StandardWelds = value; OnPropertyChanged(); } }


        public string _EndPlateType;
        public string EndPlateType { get { return _EndPlateType; } set { _EndPlateType = value; OnPropertyChanged(); } }

        public string _EndPlateThickness;
        public string EndPlateThickness { get { return _EndPlateThickness; } set { _EndPlateThickness = value; OnPropertyChanged(); } }

        public string _EndPlateLength;
        public string EndPlateLength { get { return _EndPlateLength; } set { _EndPlateLength = value; OnPropertyChanged(); } }

        public string _EndPlateWidth;
        public string EndPlateWidth { get { return _EndPlateWidth; } set { _EndPlateWidth = value; OnPropertyChanged(); } }

        public string _EndPlateColumnExtension;
        public string EndPlateColumnExtension { get { return _EndPlateColumnExtension; } set { _EndPlateColumnExtension = value; OnPropertyChanged(); } }
        #endregion

        #region GC Commands
        private RelayCommand<object> _EndPlate_Button_Click;
        public ICommand EndPlate_Button_Click { get { if (_EndPlate_Button_Click == null) { _EndPlate_Button_Click = new RelayCommand<object>(new Action<object>(EndPlateClick)); } return _EndPlate_Button_Click; } }

        private RelayCommand<object> _Haunch_Button_Click;
        public ICommand Haunch_Button_Click { get { if (_Haunch_Button_Click == null) { _Haunch_Button_Click = new RelayCommand<object>(new Action<object>(HaunchClick)); } return _Haunch_Button_Click; } }



        private RelayCommand<object> _BoltDetails_Button_Click;
        public ICommand BoltDetails_Button_Click { get { if (_BoltDetails_Button_Click == null) { _BoltDetails_Button_Click = new RelayCommand<object>(new Action<object>(BoltDetailsClick)); } return _BoltDetails_Button_Click; } }

        private RelayCommand<object> _BoltGroup_Button_Click;
        public ICommand BoltGroup_Button_Click { get { if (_BoltGroup_Button_Click == null) { _BoltGroup_Button_Click = new RelayCommand<object>(new Action<object>(BoltGroupClick)); } return _BoltGroup_Button_Click; } }

        private RelayCommand<object> _Stiffeners_Button_Click;
        public ICommand Stiffeners_Button_Click { get { if (_Stiffeners_Button_Click == null) { _Stiffeners_Button_Click = new RelayCommand<object>(new Action<object>(StiffenersClick)); } return _Stiffeners_Button_Click; } }
        #endregion

        #region GC Methods
        private void EndPlateClick(object item)
        {
            EndPlate_UC_Visibility = true;

            //Subsequent UC's hidden
            Haunch_UC_Visibility = false;
            BoltDetails_UC_Visibility = false;
            BoltGroup_UC_Visibility = false;
            Stiffeners_UC_Visibility = false;
        }
        private void HaunchClick(object item)
        {
            Haunch_UC_Visibility = true;

            //Subsequent UC's hidden
            BoltDetails_UC_Visibility = false;
            EndPlate_UC_Visibility = false;
            BoltGroup_UC_Visibility = false;
            Stiffeners_UC_Visibility = false;
        }

        private void BoltDetailsClick(object item)
        {
            BoltDetails_UC_Visibility = true;

            //Subsequent UC's hidden
            EndPlate_UC_Visibility = false;
            Haunch_UC_Visibility = false;
            BoltGroup_UC_Visibility = false;
            Stiffeners_UC_Visibility = false;
        }
        private void BoltGroupClick(object item)
        {
            BoltGroup_UC_Visibility = true;

            //Subsequent UC's hidden
            EndPlate_UC_Visibility = false;
            Haunch_UC_Visibility = false;
            BoltDetails_UC_Visibility = false;
            Stiffeners_UC_Visibility = false;
        }
        private void StiffenersClick(object item)
        {
            Stiffeners_UC_Visibility = true;

            //Subsequent UC's hidden
            EndPlate_UC_Visibility = false;
            Haunch_UC_Visibility = false;
            BoltDetails_UC_Visibility = false;
            BoltGroup_UC_Visibility = false;
        }

        #endregion

        #endregion
    }

}
