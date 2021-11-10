using eToolkit_View.Interface;
using System.Windows;

namespace SC_View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IViewModel VM)
        {
            InitializeComponent();

            DataContext = VM;
        }
    }
}
