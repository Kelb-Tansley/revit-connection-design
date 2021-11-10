using Models_SC_Proj;
using System.Collections.ObjectModel;
using System.Windows;

namespace eToolkit_View.Services
{
    public class ViewModelService
    {
        /// <summary>
        /// Method 
        /// </summary>
        /// <param name="item"></param>
        public static void CopyClick(ObservableCollection<Parameter_Items> items)
        {
            string CopyData = "";
            foreach (var ParamItem in items)
            {
                CopyData = CopyData + " public const string " + ParamItem.Description + " = '" + ParamItem.Description + "';,";
            }
            Clipboard.SetDataObject(CopyData);
        }
    }
}
