//using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models_SC_Proj
{
    /// <summary>
    /// This is the master data set for the Revit connections, excludes detailed parameters
    /// </summary>
    public class Connection_SC : ModelBase
    {
        private bool _Include_Connection;
        public bool Include_Connection { get { return _Include_Connection; } set { _Include_Connection = value; OnPropertyChanged(); } }

        private string _ElementID;
        public string ElementID { get { return _ElementID; } set { _ElementID = value; OnPropertyChanged(); } }

        private string _SiblingID;
        public string SiblingID { get { return _SiblingID; } set { _SiblingID = value; OnPropertyChanged(); } }

        private string _ConnectionType;
        public string ConnectionType { get { return _ConnectionType; } set { _ConnectionType = value; OnPropertyChanged(); } }

        private string _PrimaryElement;
        public string PrimaryElement { get { return _PrimaryElement; } set { _PrimaryElement = value; OnPropertyChanged(); } }

        private string _SecondaryElement;
        public string SecondaryElement { get { return _SecondaryElement; } set { _SecondaryElement = value; OnPropertyChanged(); } }


        private ObservableCollection<string> _CopyFromID;
        public ObservableCollection<string> CopyFromID { get { return _CopyFromID; } set { _CopyFromID = value; OnPropertyChanged(); } }


        private string _ConnectionCapacity;
        public string ConnectionCapacity { get { return _ConnectionCapacity; } set { _ConnectionCapacity = value; OnPropertyChanged(); } }

        private string _ConnectionCost;
        public string ConnectionCost { get { return _ConnectionCost; } set { _ConnectionCost = value; OnPropertyChanged(); } }

        private string _PeakLC;
        public string PeakLC { get { return _PeakLC; } set { _PeakLC = value; OnPropertyChanged(); } }

        private string _ULS_Vr;
        public string ULS_Vr { get { return _ULS_Vr; } set { _ULS_Vr = value; OnPropertyChanged(); } }

        private string _ULS_Fr;
        public string ULS_Fr { get { return _ULS_Fr; } set { _ULS_Fr = value; OnPropertyChanged(); } }

        private string _ULS_Mr;
        public string ULS_Mr { get { return _ULS_Mr; } set { _ULS_Mr = value; OnPropertyChanged(); } }

        private string _ULS_Vu_Vr;
        public string ULS_Vu_Vr { get { return _ULS_Vu_Vr; } set { _ULS_Vu_Vr = value; OnPropertyChanged(); } }

        private string _ULS_Fu_Fr;
        public string ULS_Fu_Fr { get { return _ULS_Fu_Fr; } set { _ULS_Fu_Fr = value; OnPropertyChanged(); } }

        private string _ULS_Mu_Mr;
        public string ULS_Mu_Mr { get { return _ULS_Mu_Mr; } set { _ULS_Mu_Mr = value; OnPropertyChanged(); } }


        private int _ParameterID;
        public int ParameterID
        { get { return _ParameterID; } set { _ParameterID = value; OnPropertyChanged(); } }


        //private Element _element;
        //public Element Element
        //{
        //    get { return _element; }
        //    set
        //    {
        //        _element = value;
        //        OnPropertyChanged();
        //    }
        //}
        
    }
}
