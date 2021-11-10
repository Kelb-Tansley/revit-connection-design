using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eToolKit_Classes
{
    public class MomentConnection : INotifyPropertyChanged
    {
        private string _SteelGrade;
        private string _Section_Supported;
        private string _Section_Angle;
        private double _HaunchDepth;
        private double _ConnectedtoThickness;
        private string _ColumnSection;
        private bool _ColumnStiffeners_Top;
        private bool _ColumnStiffeners_Bottom;
        private bool _ColumnStiffeners_Web;
        private string _Bolts_Diameter;
        private string _Bolts_Grade;
        private int _Bolts_Number_Rows_BelowTF;
        private int _Bolts_Number_Rows_AboveTF;
        private int _Bolts_Number_Rows_BelowBF;
        private int _Bolts_Number_Rows_AboveBF;
        private int _Bolts_Number_Lines;
        private double _Plate_EndorFin_Thickness;
        private double _Plate_EndorFin_Height;
        private double _Plate_EndorFin_Width;
        private double _Plate_EndorFin_Weld;
        private double _ULS_Vu;
        private double _ULS_Mu;
        private double _ULS_Fu;

        public string SteelGrade { get { return _SteelGrade; } set { _SteelGrade = value; OnPropertyChanged(); } }
        public string Section_Supported { get { return _Section_Supported; } set { _Section_Supported = value; OnPropertyChanged(); } }
        public string Section_Angle { get { return _Section_Angle; } set { _Section_Angle = value; OnPropertyChanged(); } }
        public double HaunchDepth { get { return _HaunchDepth; } set { _HaunchDepth = value; OnPropertyChanged(); } }
        public double ConnectedtoThickness { get { return _ConnectedtoThickness; } set { _ConnectedtoThickness = value; OnPropertyChanged(); } }
        public string ColumnSection { get { return _ColumnSection; } set { _ColumnSection = value; OnPropertyChanged(); } }
        public bool ColumnStiffeners_Top { get { return _ColumnStiffeners_Top; } set { _ColumnStiffeners_Top = value; OnPropertyChanged(); } }
        public bool ColumnStiffeners_Bottom { get { return _ColumnStiffeners_Bottom; } set { _ColumnStiffeners_Bottom = value; OnPropertyChanged(); } }
        public bool ColumnStiffeners_Web { get { return _ColumnStiffeners_Web; } set { _ColumnStiffeners_Web = value; OnPropertyChanged(); } }
        public string Bolts_Diameter { get { return _Bolts_Diameter; } set { _Bolts_Diameter = value; OnPropertyChanged(); } }
        public string Bolts_Grade { get { return _Bolts_Grade; } set { _Bolts_Grade = value; OnPropertyChanged(); } }
        public int Bolts_Number_Rows_BelowTF { get { return _Bolts_Number_Rows_BelowTF; } set { _Bolts_Number_Rows_BelowTF = value; OnPropertyChanged(); } }
        public int Bolts_Number_Rows_AboveTF { get { return _Bolts_Number_Rows_AboveTF; } set { _Bolts_Number_Rows_AboveTF = value; OnPropertyChanged(); } }
        public int Bolts_Number_Rows_BelowBF { get { return _Bolts_Number_Rows_BelowBF; } set { _Bolts_Number_Rows_BelowBF = value; OnPropertyChanged(); } }
        public int Bolts_Number_Rows_AboveBF { get { return _Bolts_Number_Rows_AboveBF; } set { _Bolts_Number_Rows_AboveBF = value; OnPropertyChanged(); } }
        public int Bolts_Number_Lines { get { return _Bolts_Number_Lines; } set { _Bolts_Number_Lines = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Thickness { get { return _Plate_EndorFin_Thickness; } set { _Plate_EndorFin_Thickness = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Height { get { return _Plate_EndorFin_Height; } set { _Plate_EndorFin_Height = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Width { get { return _Plate_EndorFin_Width; } set { _Plate_EndorFin_Width = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Weld { get { return _Plate_EndorFin_Weld; } set { _Plate_EndorFin_Weld = value; OnPropertyChanged(); } }
        public double ULS_Vu { get { return _ULS_Vu; } set { _ULS_Vu = value; OnPropertyChanged(); } }
        public double ULS_Mu { get { return _ULS_Mu; } set { _ULS_Mu = value; OnPropertyChanged(); } }
        public double ULS_Fu { get { return _ULS_Fu; } set { _ULS_Fu = value; OnPropertyChanged(); } }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
