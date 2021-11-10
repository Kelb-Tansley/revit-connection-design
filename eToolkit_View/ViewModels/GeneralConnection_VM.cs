using Models_SC_Proj.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace eToolkit_View.ViewModels
{
    public class GeneralConnection_VM /*: INotifyPropertyChanged*/
    {
        //#region UC Properties
        //public string _ConnectionName = "Connection 1";
        //public string ConnectionName { get { return _ConnectionName; } set { _ConnectionName = value; OnPropertyChanged(); } }


        //public bool _EndPlate_UC_Visibility = true;
        //public bool EndPlate_UC_Visibility { get { return _EndPlate_UC_Visibility; } set { _EndPlate_UC_Visibility = value; OnPropertyChanged(); } }

        //public bool _Haunch_UC_Visibility = false;
        //public bool Haunch_UC_Visibility { get { return _Haunch_UC_Visibility; } set { _Haunch_UC_Visibility = value; OnPropertyChanged(); } }


        //public bool _BoltDetails_UC_Visibility = false;
        //public bool BoltDetails_UC_Visibility { get { return _BoltDetails_UC_Visibility; } set { _BoltDetails_UC_Visibility = value; OnPropertyChanged(); } }

        //public bool _BoltGroup_UC_Visibility = false;
        //public bool BoltGroup_UC_Visibility { get { return _BoltGroup_UC_Visibility; } set { _BoltGroup_UC_Visibility = value; OnPropertyChanged(); } }

        //public bool _Stiffeners_UC_Visibility = false;
        //public bool Stiffeners_UC_Visibility { get { return _Stiffeners_UC_Visibility; } set { _Stiffeners_UC_Visibility = value; OnPropertyChanged(); } }
        //#endregion

        //#region Commands
        //private RelayCommand<object> _EndPlate_Button_Click;
        //public ICommand EndPlate_Button_Click { get { if (_EndPlate_Button_Click == null) { _EndPlate_Button_Click = new RelayCommand<object>(new Action<object>(EndPlateClick)); } return _EndPlate_Button_Click; } }

        //private RelayCommand<object> _Haunch_Button_Click;
        //public ICommand Haunch_Button_Click { get { if (_Haunch_Button_Click == null) { _Haunch_Button_Click = new RelayCommand<object>(new Action<object>(HaunchClick)); } return _Haunch_Button_Click; } }



        //private RelayCommand<object> _BoltDetails_Button_Click;
        //public ICommand BoltDetails_Button_Click { get { if (_BoltDetails_Button_Click == null) { _BoltDetails_Button_Click = new RelayCommand<object>(new Action<object>(BoltDetailsClick)); } return _BoltDetails_Button_Click; } }

        //private RelayCommand<object> _BoltGroup_Button_Click;
        //public ICommand BoltGroup_Button_Click { get { if (_BoltGroup_Button_Click == null) { _BoltGroup_Button_Click = new RelayCommand<object>(new Action<object>(BoltGroupClick)); } return _BoltGroup_Button_Click; } }

        //private RelayCommand<object> _Stiffeners_Button_Click;
        //public ICommand Stiffeners_Button_Click { get { if (_Stiffeners_Button_Click == null) { _Stiffeners_Button_Click = new RelayCommand<object>(new Action<object>(StiffenersClick)); } return _Stiffeners_Button_Click; } } 
        //#endregion
        
        //#region Methods
        //private void EndPlateClick(object item)
        //{
        //    EndPlate_UC_Visibility = true;

        //    //Subsequent UC's hidden
        //    Haunch_UC_Visibility = false;
        //    BoltDetails_UC_Visibility = false;
        //    BoltGroup_UC_Visibility = false;
        //    Stiffeners_UC_Visibility = false;
        //}
        //private void HaunchClick(object item)
        //{
        //    Haunch_UC_Visibility = true;

        //    //Subsequent UC's hidden
        //    BoltDetails_UC_Visibility = false;
        //    EndPlate_UC_Visibility = false;
        //    BoltGroup_UC_Visibility = false;
        //    Stiffeners_UC_Visibility = false;
        //}

        //private void BoltDetailsClick(object item)
        //{
        //    BoltDetails_UC_Visibility = true;

        //    //Subsequent UC's hidden
        //    EndPlate_UC_Visibility = false;
        //    Haunch_UC_Visibility = false;
        //    BoltGroup_UC_Visibility = false;
        //    Stiffeners_UC_Visibility = false;
        //}
        //private void BoltGroupClick(object item)
        //{
        //    BoltGroup_UC_Visibility = true;

        //    //Subsequent UC's hidden
        //    EndPlate_UC_Visibility = false;
        //    Haunch_UC_Visibility = false;
        //    BoltDetails_UC_Visibility = false;
        //    Stiffeners_UC_Visibility = false;
        //}
        //private void StiffenersClick(object item)
        //{
        //    Stiffeners_UC_Visibility = true;

        //    //Subsequent UC's hidden
        //    EndPlate_UC_Visibility = false;
        //    Haunch_UC_Visibility = false;
        //    BoltDetails_UC_Visibility = false;
        //    BoltGroup_UC_Visibility = false;
        //}

        //#endregion



        //#region MyRegion
        //public string _BoltDiameter;
        //public string BoltDiameter { get { return _BoltDiameter; } set { _BoltDiameter = value; OnPropertyChanged(); } }
        //#endregion


        //#region INotifyPropertyChanged Members
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //#endregion
    }
}
