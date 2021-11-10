using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eToolKit_Classes
{
    public class ColumnBase : INotifyPropertyChanged
    {
        private string _SteelGrade;
        private string _ColumnSection;
        private double _Bolts_Diameter;
        private string _Bolts_Grade;
        private int _Bolts_HD_Number;
        private double _Bolts_HD_Length;
        private double _Plate_EndorFin_Thickness;
        private double _Plate_EndorFin_Height;
        private double _Plate_EndorFin_Width;
        private double _Plate_EndorFin_Weld;
        private double _ULS_Vu;
        private double _ULS_Mu;
        private double _ULS_Fu;
        private bool _ShearKey_IsPresent;
        private double _ShearKey_Depth;
        private double _ShearKey_Thickness;
        private double _ShearKey_Weld;
        private double _Concrete_Grade;
        private double _Concrete_BasetoPlinth_X1;
        private double _Concrete_BasetoPlinth_X2;
        private double _Concrete_BasetoPlinth_Y1;
        private double _Concrete_BasetoPlinth_Y2;

        public string SteelGrade { get { return _SteelGrade; } set { _SteelGrade = value; OnPropertyChanged(); } }
        public string ColumnSection { get { return _ColumnSection; } set { _ColumnSection = value; OnPropertyChanged(); } }
        public double Bolts_Diameter { get { return _Bolts_Diameter; } set { _Bolts_Diameter = value; OnPropertyChanged(); } }
        public string Bolts_Grade { get { return _Bolts_Grade; } set { _Bolts_Grade = value; OnPropertyChanged(); } }
        public int Bolts_HD_Number { get { return _Bolts_HD_Number; } set { _Bolts_HD_Number = value; OnPropertyChanged(); } }
        public double Bolts_HD_Length { get { return _Bolts_HD_Length; } set { _Bolts_HD_Length = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Thickness { get { return _Plate_EndorFin_Thickness; } set { _Plate_EndorFin_Thickness = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Height { get { return _Plate_EndorFin_Height; } set { _Plate_EndorFin_Height = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Width { get { return _Plate_EndorFin_Width; } set { _Plate_EndorFin_Width = value; OnPropertyChanged(); } }
        public double Plate_EndorFin_Weld { get { return _Plate_EndorFin_Weld; } set { _Plate_EndorFin_Weld = value; OnPropertyChanged(); } }
        public double ULS_Vu { get { return _ULS_Vu; } set { _ULS_Vu = value; OnPropertyChanged(); } }
        public double ULS_Mu { get { return _ULS_Mu; } set { _ULS_Mu = value; OnPropertyChanged(); } }
        public double ULS_Fu { get { return _ULS_Fu; } set { _ULS_Fu = value; OnPropertyChanged(); } }
        public bool ShearKey_IsPresent { get { return _ShearKey_IsPresent; } set { _ShearKey_IsPresent = value; OnPropertyChanged(); } }
        public double ShearKey_Depth { get { return _ShearKey_Depth; } set { _ShearKey_Depth = value; OnPropertyChanged(); } }
        public double ShearKey_Thickness { get { return _ShearKey_Thickness; } set { _ShearKey_Thickness = value; OnPropertyChanged(); } }
        public double ShearKey_Weld { get { return _ShearKey_Weld; } set { _ShearKey_Weld = value; OnPropertyChanged(); } }
        public double Concrete_Grade { get { return _Concrete_Grade; } set { _Concrete_Grade = value; OnPropertyChanged(); } }
        public double Concrete_BasetoPlinth_X1 { get { return _Concrete_BasetoPlinth_X1; } set { _Concrete_BasetoPlinth_X1 = value; OnPropertyChanged(); } }
        public double Concrete_BasetoPlinth_X2 { get { return _Concrete_BasetoPlinth_X2; } set { _Concrete_BasetoPlinth_X2 = value; OnPropertyChanged(); } }
        public double Concrete_BasetoPlinth_Y1 { get { return _Concrete_BasetoPlinth_Y1; } set { _Concrete_BasetoPlinth_Y1 = value; OnPropertyChanged(); } }
        public double Concrete_BasetoPlinth_Y2 { get { return _Concrete_BasetoPlinth_Y2; } set { _Concrete_BasetoPlinth_Y2 = value; OnPropertyChanged(); } }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
