using Autodesk.Revit.UI;
using eToolkit_View.Interface;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RevitConnectionDesign
{
    public class App : IExternalApplication
    {
        const string Ribbon_Tab = "Connections";
        const string Ribbon_Panel = "Steel Connection Design";

        Result IExternalApplication.OnStartup(UIControlledApplication application)
        {
            var service = FirstFloor.XamlSpy.Services.XamlSpyService.Current;
            service.Connect();

            m_MyForm = null;   // no dialog needed yet; the command will bring it
            thisApp = this;  // static access to this application instance

            //get or create the panel
            RibbonPanel panel = null;
            //List<RibbonPanel> panels = application.GetRibbonPanels(Ribbon_Tab);
            List<RibbonPanel> panels = application.GetRibbonPanels();
            foreach (RibbonPanel pnl in panels)
            {
                if (pnl.Name == Ribbon_Panel)
                {
                    panel = pnl;
                    break;
                }
            }

            //couldnt find the panel, create new
            if (panel == null)
            {
                panel = application.CreateRibbonPanel(Ribbon_Panel);
            }

            //get the image for the button
            Image img = global::RevitConnectionDesign.Properties.Resources.Image_24;
            ImageSource imgSrc = GetImageSource(img);

            //create the button data
            PushButtonData btnData = new PushButtonData(
                "MyButton",
                "Connection Design",
                Assembly.GetExecutingAssembly().Location,
                "RevitConnectionDesign.ConnectionDesign"
                )
            {
                ToolTip = "Structural Connection Design Tool",
                LongDescription = "This tool designs steel connections externally to SANS 10162:1",
                Image = imgSrc,
                LargeImage = imgSrc
            };

            //add the button to the ribbon
            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;

            return Result.Succeeded;
        }

        private BitmapSource GetImageSource(Image img)
        {
            BitmapImage bmp = new BitmapImage();
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                bmp.BeginInit();

                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.UriSource = null;
                bmp.StreamSource = ms;

                bmp.EndInit();
            }

            return bmp;
        }

        Result IExternalApplication.OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        // class instance
        internal static App thisApp = null;
        // ModelessForm instance
        private SC_View.MainWindow m_MyForm;

        /// <summary>
        ///   This method creates and shows a modeless dialog, unless it already exists.
        /// </summary>
        /// <remarks>
        ///   The external command invokes this on the end-user's request
        /// </remarks>
        /// 
        public void ShowForm(IViewModel viewModel)
        {
            // If we do not have a dialog yet, create and show it
            if (m_MyForm == null || !m_MyForm.IsActive)
            {
                // We give the objects to the new dialog;
                // The dialog becomes the owner responsible fore disposing them, eventually.
                m_MyForm = new SC_View.MainWindow(viewModel);
                m_MyForm.Show();
            }
        }
    }
}
