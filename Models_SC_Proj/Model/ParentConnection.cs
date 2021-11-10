using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_SC_Proj.Model
{
    public class ParentConnection : ModelBase
    {

        private bool _Include_Connection;
        public bool Include_Connection { get { return _Include_Connection; } set { _Include_Connection = value; OnPropertyChanged(); } }

        private string _ElementID;
        public string ElementID { get { return _ElementID; } set { _ElementID = value; OnPropertyChanged(); } }

        private string _ConnectionType;
        public string ConnectionType { get { return _ConnectionType; } set { _ConnectionType = value; OnPropertyChanged(); } }

        private ObservableCollection<Connection_SC> _ChildConnection;
        public ObservableCollection<Connection_SC> ChildConnection { get { return _ChildConnection; } set { _ChildConnection = value; OnPropertyChanged(); } }
    }
}
