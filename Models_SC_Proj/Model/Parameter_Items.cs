using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models_SC_Proj
{
    /// <summary>
    /// This entity reflects the returned parameters for the 3rd party connection
    /// </summary>
    public class Parameter_Items : ModelBase
    {
        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; OnPropertyChanged(); } }

        private string _Value;
        public string Value { get { return _Value; } set { _Value = value; OnPropertyChanged(); } }
    }
}
