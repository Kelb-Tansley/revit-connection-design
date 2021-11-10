using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eToolKit_Classes
{
    public class SimpleConnection : INotifyPropertyChanged
    {
        private string _SteelGrade;
        private string _Section_Supported;
        private string _ConnectionAngle_Section;
        private double _ConnectionAngle_Length;
        private double _ConnectedtoThickness;
        private bool _Notch_None;
        private bool _Notch_Top;
        private double _Notch_Top_Width;
        private bool _Notch_TandB;
        private double _Notch_TandB_Width;
        private double _Notch_Depth;
        private double _Notch_Length;
        private double _Bolts_Diameter;
        private string _Bolts_Grade;
        private int _Bolts_Number_Rows_BelowTF;
        private int _Bolts_Number_Lines;
        private double _Plate_EndorFin_Thickness;
        private double _Plate_EndorFin_Height;
        private double _Plate_EndorFin_Width;
        private double _Plate_EndorFin_Weld;
        private double _ULS_Vu;
        private double _ULS_Fu;

        public string SteelGrade { get { return _SteelGrade; } set { _SteelGrade = value; OnPropertyChanged(); } }
        public string Section_Supported { get { return _Section_Supported; } set { _Section_Supported = value; OnPropertyChanged(); } }
        public string ConnectionAngle_Section { get { return _ConnectionAngle_Section; } set { _ConnectionAngle_Section = value; OnPropertyChanged(); } }
        public double ConnectionAngle_Length { get { return _ConnectionAngle_Length; } set { _ConnectionAngle_Length = value; OnPropertyChanged(); } }
        public double ConnectedtoThickness { get { return _ConnectedtoThickness; } set { _ConnectedtoThickness = value; OnPropertyChanged(); } }
        public bool Notch_None { get { return _Notch_None; } set { _Notch_None = value; OnPropertyChanged(); } }
        public bool Notch_Top { get { return _Notch_Top; } set { _Notch_Top = value; OnPropertyChanged(); } }
        public double Notch_Top_Width { get { return _Notch_Top_Width; } set { _Notch_Top_Width = value; OnPropertyChanged(); } }
        public bool Notch_TandB { get { return _Notch_TandB; } set { _Notch_TandB = value; OnPropertyChanged(); } }
        public double Notch_TandB_Width { get { return _Notch_TandB_Width; } set { _Notch_TandB_Width = value; OnPropertyChanged(); } }
        public double Notch_Depth { get { return _Notch_Depth; } set { _Notch_Depth = value; OnPropertyChanged(); } }
        public double Notch_Length { get { return _Notch_Length; } set { _Notch_Length = value; OnPropertyChanged(); } }
        public double Bolts_Diameter { get { return _Bolts_Diameter; } set { _Bolts_Diameter = value; OnPropertyChanged(); } }
        public string Bolts_Grade { get { return _Bolts_Grade; } set { _Bolts_Grade = value; OnPropertyChanged(); } }
        public int Bolts_Number_Rows_BelowTF { get { return _Bolts_Number_Rows_BelowTF; } set { _Bolts_Number_Rows_BelowTF = value; OnPropertyChanged(); } }
        public int Bolts_Number_Lines { get { return _Bolts_Number_Lines; } set { _Bolts_Number_Lines = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Thickness { get { return _Plate_EndorFin_Thickness; } set { _Plate_EndorFin_Thickness = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Height { get { return _Plate_EndorFin_Height; } set { _Plate_EndorFin_Height = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Width { get { return _Plate_EndorFin_Width; } set { _Plate_EndorFin_Width = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Weld { get { return _Plate_EndorFin_Weld; } set { _Plate_EndorFin_Weld = value; OnPropertyChanged(); } }
        public double ULS_Vu { get { return _ULS_Vu; } set { _ULS_Vu = value; OnPropertyChanged(); } }
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
