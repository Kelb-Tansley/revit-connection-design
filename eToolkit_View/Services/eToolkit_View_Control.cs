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
using System.Windows.Input;
using System.Windows.Interop;

namespace eToolkit_View
{
    public class eToolkit_View_Control
    {
        /// <summary>
        /// Handle to the eTookit Home Window
        /// </summary>
        public static IntPtr _eToolkitHomeWin;

        public eToolkit_View_Control()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.GetType() == (Application.Current.MainWindow).GetType())
                {
                    //object thisframe = new object();
                    //thisframe = item.DataContext;

                    //var helpers = new WindowInteropHelper(item);

                    //ObservableCollection<UIElement> someElements = new ObservableCollection<UIElement>();
                    //Grid thiscontent = (Grid)item.Content;
                    //someElements = GetUIElements(thiscontent);

                    //Rectangle myRect = new Rectangle();

                    //RECT rct;

                    //if (!GetWindowRect(new HandleRef(item, helpers.Handle), out rct))
                    //{
                    //}
                    //myRect.X = rct.Left;
                    //myRect.Y = rct.Top;
                    //myRect.Width = rct.Right - rct.Left + 1;
                    //myRect.Height = rct.Bottom - rct.Top + 1;



                    AutomationElement desktopObject = AutomationElement.RootElement;

                    //System.Windows.Automation.Condition testWindowNameCondition = new PropertyCondition(AutomationElement.NameProperty, "eToolKit - Structural Steel Connections");

                    System.Windows.Automation.Condition testWindowNameCondition = new PropertyCondition(AutomationElement.NameProperty, "Connection Design");
                    AutomationElement testWindow = desktopObject.FindFirst(TreeScope.Children, testWindowNameCondition);

                    LoadeToolKitConnectionType(testWindow, 0);
                    LoadeToolKitCalculator(testWindow, 0);

                    WindowInteropHelper helper = new WindowInteropHelper(Window.GetWindow(Application.Current.MainWindow));
                    int AHeight = Convert.ToInt32(Application.Current.MainWindow.ActualHeight);
                    int AWidth = Convert.ToInt32(Application.Current.MainWindow.ActualWidth / 2);

                    PositioneToolKitCalculator(helper, AHeight, AWidth);

                    StartAutomation(testWindow);

                    //ObservableCollection<UIElement> someElements = new ObservableCollection<UIElement>();
                    //Grid thiscontent = (Grid)item.Content;
                    //someElements = GetUIElements(thiscontent);

                    //System.Windows.Automation.Condition textConditionOne = new PropertyCondition(AutomationElement.AutomationIdProperty, "Moment Connections");
                    //AutomationElement textOne = testWindow.FindFirst(TreeScope.Descendants, textConditionOne);



                    //ValuePattern valuetextOne = textOne.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    //valuetextOne.SetValue("4");

                    //private void btnStartAutomation_Click(object sender, RoutedEventArgs e)
                    //{
                    //    Thread automateThread = new Thread(new ThreadStart(StartAutomation));
                    //    automateThread.Start();
                    //}


                    //foreach (var item2 in item.DataContext)
                    //{
                    //    item2.
                    //    UIElement gridview = new UIElement();
                    //    gridview.
                    //}

                    //_xpos = Convert.ToInt32(item.Left);
                    //_ypos = Convert.ToInt32(item.Top);


                }
            }
        }

        private ObservableCollection<UIElement> GetUIElements(Grid thiscontent)
        {
            ObservableCollection<UIElement> localElements = new ObservableCollection<UIElement>();

            if (thiscontent.Children.Count > 0)
            {
                foreach (UIElement UIitem in thiscontent.Children)
                {
                    if (UIitem.GetType() == typeof(Grid))
                    {
                        GetUIElements((Grid)UIitem);
                    }
                    else if (UIitem.GetType() == typeof(ContentControl))
                    {
                        localElements.Add(UIitem);
                    }
                }
            }
            return localElements;
        }

        private void LoadeToolKitConnectionType(AutomationElement targetTreeViewElement, int treeviewIndex)
        {
            if (targetTreeViewElement == null)
                return;

            AutomationElement elementNode = TreeWalker.ControlViewWalker.GetFirstChild(targetTreeViewElement);

            while (elementNode != null)
            {
                //// Compile information about the control.
                //StringBuilder elementInfoCompile = new StringBuilder();
                //string controlName = (elementNode.Current.Name == "") ? "Unnamed control" : elementNode.Current.Name;
                //string autoIdName = (elementNode.Current.AutomationId == "") ? "No AutomationID" : elementNode.Current.AutomationId;

                //elementInfoCompile.Append(controlName)
                //    .Append(" (")
                //    .Append(elementNode.Current.ControlType.LocalizedControlType)
                //    .Append(" - ")
                //    .Append(autoIdName)
                //    .Append(")");

                //string connectionType = "Simple Connections";
                string connectionType = "Moment Connections";
                //string connectionType = "Splice Connections";
                //string connectionType = "Column Bases";
                //string connectionType = "Embed Plates";
                object objPattern2;
                if (elementNode.Current.Name == connectionType)
                {
                    if (true == elementNode.TryGetCurrentPattern(InvokePattern.Pattern, out objPattern2))
                    {
                        System.Windows.Point clickable = elementNode.GetClickablePoint();
                        System.Drawing.Point Pcurrent = System.Windows.Forms.Cursor.Position;

                        System.Drawing.Point P1 = new System.Drawing.Point((int)clickable.X, (int)clickable.Y);
                        System.Windows.Forms.Cursor.Position = P1;

                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Convert.ToUInt32(P1.X), Convert.ToUInt32(P1.Y), 0, 0);

                        System.Windows.Forms.Cursor.Position = Pcurrent;
                    }
                }

                //// Test for the control patterns of interest for this sample.
                //object objPattern;
                //ExpandCollapsePattern expcolPattern;
                //if (true == elementNode.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out objPattern))
                //{
                //    expcolPattern = objPattern as ExpandCollapsePattern;
                //    if (expcolPattern.Current.ExpandCollapseState != ExpandCollapseState.LeafNode)
                //    {
                //    }
                //}
                //if (true == elementNode.TryGetCurrentPattern(TogglePattern.Pattern, out objPattern))
                //{
                //    //    togPattern = objPattern as TogglePattern;
                //}
                //if (true == elementNode.TryGetCurrentPattern(InvokePattern.Pattern, out objPattern))
                //{
                //}
                
                // Iterate to next element.
                // elementNode - Current element.
                // treeviewIndex - Index of parent TreeView.
                LoadeToolKitConnectionType(elementNode, treeviewIndex);
                elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode);
            }
        }

        private void LoadeToolKitCalculator(AutomationElement targetTreeViewElement, int treeviewIndex)
        {
            if (targetTreeViewElement == null)
                return;

            AutomationElement elementNode = TreeWalker.ControlViewWalker.GetFirstChild(targetTreeViewElement);

            while (elementNode != null)
            {
                InvokePattern invPatternloc;
                object objPattern2;

                if (elementNode.Current.Name == "Tool")
                {
                    if (true == elementNode.TryGetCurrentPattern(InvokePattern.Pattern, out objPattern2))
                    {
                        invPatternloc = objPattern2 as InvokePattern;
                        invPatternloc.Invoke();
                    }
                }

                // Iterate to next element.
                LoadeToolKitCalculator(elementNode, treeviewIndex);
                elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode);
            }
        }


        private void StartAutomation(AutomationElement targetTreeViewElement)
        {
            // Get the root element or Desktop
            //AutomationElement desktopObject = AutomationElement.RootElement;
            AutomationElement desktopObject = TreeWalker.ControlViewWalker.GetFirstChild(targetTreeViewElement);


            //Define a condition for getting the Demo window by its name property
            //System.Windows.Automation.Condition testWindowNameCondition = new PropertyCondition(AutomationElement.NameProperty, "Demo Window For Csharp Automation");
            //System.Windows.Automation.Condition textConditionOne = new PropertyCondition(AutomationElement.AutomationIdProperty, "InputOne");
            //System.Windows.Automation.Condition textConditionTwo = new PropertyCondition(AutomationElement.AutomationIdProperty, "InputTwo");
            //System.Windows.Automation.Condition textConditionTotal = new PropertyCondition(AutomationElement.AutomationIdProperty, "Total");


            ////Based on the above condion, loop through all tree nodes of Desktop to get the window that has the same name 
            //AutomationElement testWindow = desktopObject.FindFirst(TreeScope.Children, testWindowNameCondition);
            ////Now that you have the handl on the window , access its objects or elements and set values


            //AutomationElement textOne = testWindow.FindFirst(TreeScope.Descendants, textConditionOne);
            //ValuePattern valuetextOne = textOne.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            //valuetextOne.SetValue("4");


            //AutomationElement textTwo = testWindow.FindFirst(TreeScope.Descendants, textConditionTwo);
            //ValuePattern valuetextTwo = textTwo.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            //valuetextTwo.SetValue("14");


            //AutomationElement textThree = testWindow.FindFirst(TreeScope.Descendants, textConditionTotal);
            //ValuePattern valuetextThree = textThree.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            //valuetextThree.SetValue("18");

            while (desktopObject != null)
            {
                InvokePattern invPatternloc;
                object objPattern2;
                string itemname = desktopObject.Current.Name;
                if (desktopObject.Current.Name == "305")
                {
                    if (true == desktopObject.TryGetCurrentPattern(InvokePattern.Pattern, out objPattern2))
                    {
                        invPatternloc = objPattern2 as InvokePattern;
                        invPatternloc.Invoke();
                    }
                }
                //if (desktopObject.Current.Name == "CALCULATE")
                //{
                //    if (true == desktopObject.TryGetCurrentPattern(InvokePattern.Pattern, out objPattern2))
                //    {
                //        invPatternloc = objPattern2 as InvokePattern;
                //        invPatternloc.Invoke();
                //    }
                //}

                // Iterate to next element.
                StartAutomation(desktopObject);
                desktopObject = TreeWalker.ControlViewWalker.GetNextSibling(desktopObject);
            }

        }

        private void PositioneToolKitCalculator(WindowInteropHelper helper, int AHeight, int AWidth)
        {
            /// <summary>
            /// Handle to the application Window
            /// </summary>
            IntPtr _appWin;

            Process[] processlist = Process.GetProcesses();
            
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.MainWindowTitle=="Simple Connections Tool" || process.MainWindowTitle == "Moment Connections Tool")
                    {
                        // Initialize handle value to invalid
                        _appWin = IntPtr.Zero;
                        try
                        {
                            //User32.MoveWindow(_eToolkitHomeWin, 10000, 10000, AWidth, AHeight, true);

                            // Get the main handle
                            _appWin = process.MainWindowHandle;
                        }
                        catch (Exception ex)
                        {
                            Debug.Print(ex.Message + "Error");
                        }

                        // Put it into this form
                        User32.SetParent(_appWin, helper.Handle);

                        //// Remove border and whatnot
                        //User32.SetWindowLongA(_appWin, User32.GWL_STYLE, User32.WS_VISIBLE);

                        //// Move the window to overlay it on this window
                        //User32.MoveWindow(_appWin, 50, 50, AWidth, AHeight, true);

                        return;
                    }
                    else if (process.MainWindowTitle == "Splice Connections Tool")
                    {

                    }
                    else if (process.MainWindowTitle == "Holding Down Bolts Tool")
                    {

                    }
                    else if (process.MainWindowTitle == "Embed Plates Tool")
                    {

                    }
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
    }
}
