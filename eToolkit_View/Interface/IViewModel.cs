using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Models_SC_Proj;
using RevitConnectionProperties.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eToolkit_View.Interface
{
    public interface IViewModel
    {
        ObservableCollection<Connection_SC> ConnectionList { get; set; }
        ObservableCollection<Parameter_Items> Parameters { get; set; }
        ObservableCollection<ObservableCollection<Parameter_Items>> ParametersMasterList { get; set; }
        ObservableCollection<ObservableCollection<LoadCombinationItem>> LoadCombinationMasterList { get; set; }

        IList<Reference> SelectedElements { get; set; }

        ExternalEvent exEvent { get; set; }

        eToolkit_to_Revit handler { get; set; }
    }
}
