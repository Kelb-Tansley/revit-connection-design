using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eToolkit_View
{
    /// <summary>
    /// Interaction logic for eToolkit_UC.xaml
    /// </summary>
    public partial class eToolkit_UC : UserControl
    {
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct HWND__
        {
            /// int
            public int unused;
        }


        public eToolkit_UC()
        {
            InitializeComponent();

            this.SizeChanged += new SizeChangedEventHandler(OnSizeChanged);
            this.Loaded += new RoutedEventHandler(OnVisibleChanged);
            this.SizeChanged += new SizeChangedEventHandler(OnResize);
        }


        ~eToolkit_UC()
        {
            this.Dispose();
        }

        /// <summary>
        /// Track if the application has been created
        /// </summary>
        private bool _iscreated = false;

        /// <summary>
        /// Track if the control is disposed
        /// </summary>
        private bool _isdisposed = false;


        private Process _childp;

        /// <summary>
        /// The name of the exe to launch
        /// </summary>
        private string exeName = "C:\\Users\\Tans73647\\Desktop\\eToolKit_V5.01D_K.Tansley.exe";

        public string ExeName { get { return exeName; } set { exeName = value; } }


        /// <summary>
        /// Force redraw of control when size changes
        /// </summary>
        /// <param name="e">Not used</param>
        protected void OnSizeChanged(object s, SizeChangedEventArgs e)
        {
            this.InvalidateVisual();
        }


        /// <summary>
        /// Create control when visibility changes
        /// </summary>
        /// <param name="e">Not used</param>
        protected void OnVisibleChanged(object s, RoutedEventArgs e)
        {
            // If control needs to be initialized/created
            if (_iscreated == false)
            {

                // Mark that control is created
                _iscreated = true;

                // Initialize handle value to invalid
                eToolkit_View_Control._eToolkitHomeWin = IntPtr.Zero;

                try
                {
                    var procInfo = new System.Diagnostics.ProcessStartInfo(this.exeName);
                    procInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(this.exeName);
                    // Start the process
                    _childp = System.Diagnostics.Process.Start(procInfo);

                    // Wait for process to be created and enter idle condition
                    _childp.WaitForInputIdle();

                    // Get the main handle
                    eToolkit_View_Control._eToolkitHomeWin = _childp.MainWindowHandle;
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message + "Error");
                }

                // Put it into this form
                var helper = new WindowInteropHelper(Window.GetWindow(this.AppContainer));
                User32.SetParent(eToolkit_View_Control._eToolkitHomeWin, helper.Handle);

                // Remove border and whatnot
                User32.SetWindowLongA(eToolkit_View_Control._eToolkitHomeWin, User32.GWL_STYLE, User32.WS_VISIBLE);

                // Move the window to overlay it on this window
                //User32.MoveWindow(eToolkit_View_Control._eToolkitHomeWin, 0, 0, (int)this.ActualWidth, (int)this.ActualHeight, true);
                User32.MoveWindow(eToolkit_View_Control._eToolkitHomeWin, 0, 0, 750, (int)this.ActualHeight, true);

            }
        }

        /// <summary>
        /// Update display of the executable
        /// </summary>
        /// <param name="e">Not used</param>
        protected void OnResize(object s, SizeChangedEventArgs e)
        {
            if (eToolkit_View_Control._eToolkitHomeWin != IntPtr.Zero)
            {
                User32.MoveWindow(eToolkit_View_Control._eToolkitHomeWin, 0, 0, (int)this.ActualWidth, (int)this.ActualHeight, true);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isdisposed)
            {
                if (disposing)
                {
                    if (_iscreated && eToolkit_View_Control._eToolkitHomeWin != IntPtr.Zero && !_childp.HasExited)
                    {
                        // Stop the application
                        _childp.Kill();

                        // Clear internal handle
                        eToolkit_View_Control._eToolkitHomeWin = IntPtr.Zero;
                    }
                }
                _isdisposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
