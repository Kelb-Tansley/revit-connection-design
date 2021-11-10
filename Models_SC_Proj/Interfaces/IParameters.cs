using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_SC_Proj.Interfaces
{
    public interface IParameters
    {

        //List of parameter items for each connection
        ObservableCollection<ObservableCollection<Parameter_Items>> ParametersMasterList { get; set; }
    }
}
