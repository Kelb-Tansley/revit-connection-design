using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading;

namespace Strand7
{
    public class Strand7APICallsAndControls
    {
        /// <summary>
        /// Checks Connection to the Strand7 API 
        /// </summary>
        /// <returns></returns>
        public static bool CheckAPIconnection()
        {
            try
            {
                if (HandleError(St7.St7Init())) { St7.St7Release(); }
                return true;
            }
            catch (Exception)
            {
                //RunSANSDesign.IsEnabled = false;
                MessageBox.Show("Connection to Strand7 has failed.", "Network/API Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Checks Connection to the Strand7 API 
        /// </summary>
        /// <returns></returns>
        public static bool CheckAPIconnection_WithThread(Thread thread)
        {
            try
            {
                if (HandleError_WithThread(St7.St7Init(), thread)) { St7.St7Release(); }
                return true;
            }
            catch (Exception)
            {
                //RunSANSDesign.IsEnabled = false;
                MessageBox.Show("Connection to Strand7 has failed.", "Network/API Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Calls Strand API Error Checks
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <returns></returns>
        public static bool HandleError(int ErrorCode)
        {
            if (ErrorCode != St7.ERR7_NoError)
            {
                StringBuilder sbErrorString = new StringBuilder(St7.kMaxStrLen);
                if (St7.ERR7_NoError == St7.St7GetAPIErrorString(ErrorCode, sbErrorString, sbErrorString.Capacity))
                {
                    MessageBox.Show(sbErrorString.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (St7.ERR7_NoError == St7.St7GetSolverErrorString(ErrorCode, sbErrorString, sbErrorString.Capacity))
                {
                    MessageBox.Show(sbErrorString.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Calls Strand API Error Checks
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <returns></returns>
        public static bool HandleError_WithThread(int ErrorCode, Thread thread)
        {
            if (ErrorCode != St7.ERR7_NoError)
            {
                StringBuilder sbErrorString = new StringBuilder(St7.kMaxStrLen);
                if (St7.ERR7_NoError == St7.St7GetAPIErrorString(ErrorCode, sbErrorString, sbErrorString.Capacity))
                {                    
                    MessageBox.Show(sbErrorString.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (St7.ERR7_NoError == St7.St7GetSolverErrorString(ErrorCode, sbErrorString, sbErrorString.Capacity))
                {
                    MessageBox.Show(sbErrorString.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return true;
            }
            else
                return false;
        }
    }
}
