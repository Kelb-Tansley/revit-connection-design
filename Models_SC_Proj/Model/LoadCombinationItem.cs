
namespace Models_SC_Proj
{
    /// <summary>
    /// Loads applied to 3rd party connection
    /// </summary>
    public class LoadCombinationItem : ModelBase
    {
        private string _LoadCombinationName;
        public string LoadCombinationName { get { return _LoadCombinationName; } set { _LoadCombinationName = value; OnPropertyChanged(); } }

        private string _Vu;
        public string Vu { get { return _Vu; } set { _Vu = value; OnPropertyChanged(); } }

        private string _Fu;
        public string Fu { get { return _Fu; } set { _Fu = value; OnPropertyChanged(); } }

        private string _Mu;
        public string Mu { get { return _Mu; } set { _Mu = value; OnPropertyChanged(); } }
    }
}
