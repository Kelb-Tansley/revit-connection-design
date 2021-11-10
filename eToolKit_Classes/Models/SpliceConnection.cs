using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eToolKit_Classes
{
    public class SpliceConnection : INotifyPropertyChanged
    {
        private string _SteelGrade;
        private string _Section_Supported;
        private string _Section_Supporting;
        private double _Bolts_Diameter;
        private string _Bolts_Grade;
        private int _Bolts_Number_Rows_InFlange;
        private int _Bolts_Number_Rows_InWeb;
        private int _Bolts_Number_Lines_InFlange;
        private int _Bolts_Number_Lines_InWeb;
        private double _Plate_Web_Thickness;
        private double _Plate_Web_Height;
        private double _Plate_Web_Width;
        private bool _Plate_Flange_Inside;
        private double _Plate_Flange_Thickness;
        private double _Plate_Flange_Height;
        private double _Plate_Flange_Width;
        private double _ULS_Vu;
        private double _ULS_Mu;
        private double _ULS_Fu;

        public string SteelGrade { get { return _SteelGrade; } set { _SteelGrade = value; OnPropertyChanged(); } }
        public string Section_Supported { get { return _Section_Supported; } set { _Section_Supported = value; OnPropertyChanged(); } }
        public string Section_Supporting { get { return _Section_Supporting; } set { _Section_Supporting = value; OnPropertyChanged(); } }
        public double Bolts_Diameter { get { return _Bolts_Diameter; } set { _Bolts_Diameter = value; OnPropertyChanged(); } }
        public string Bolts_Grade { get { return _Bolts_Grade; } set { _Bolts_Grade = value; OnPropertyChanged(); } }
        public int Bolts_Number_Rows_InFlange { get { return _Bolts_Number_Rows_InFlange; } set { _Bolts_Number_Rows_InFlange = value; OnPropertyChanged(); } }
        public int Bolts_Number_Rows_InWeb { get { return _Bolts_Number_Rows_InWeb; } set { _Bolts_Number_Rows_InWeb = value; OnPropertyChanged(); } }
        public int Bolts_Number_Lines_InFlange { get { return _Bolts_Number_Lines_InFlange; } set { _Bolts_Number_Lines_InFlange = value; OnPropertyChanged(); } }
        public int Bolts_Number_Lines_InWeb { get { return _Bolts_Number_Lines_InWeb; } set { _Bolts_Number_Lines_InWeb = value; OnPropertyChanged(); } }
        public double Plate_Web_Thickness { get { return _Plate_Web_Thickness; } set { _Plate_Web_Thickness = value; OnPropertyChanged(); } }
        public double Plate_Web_Height { get { return _Plate_Web_Height; } set { _Plate_Web_Height = value; OnPropertyChanged(); } }
        public double Plate_Web_Width { get { return _Plate_Web_Width; } set { _Plate_Web_Width = value; OnPropertyChanged(); } }
        public bool Plate_Flange_Inside { get { return _Plate_Flange_Inside; } set { _Plate_Flange_Inside = value; OnPropertyChanged(); } }
        public double Plate_Flange_Thickness { get { return _Plate_Flange_Thickness; } set { _Plate_Flange_Thickness = value; OnPropertyChanged(); } }
        public double Plate_Flange_Height { get { return _Plate_Flange_Height; } set { _Plate_Flange_Height = value; OnPropertyChanged(); } }
        public double Plate_Flange_Width { get { return _Plate_Flange_Width; } set { _Plate_Flange_Width = value; OnPropertyChanged(); } }
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
