using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogger.Util
{
    internal static class ScreenshotEvent
    {
        public static readonly string tempPath = System.IO.Path.GetTempPath();
        public static void CaptureScreen()
        {
            try
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                Bitmap captureBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                captureBitmap.Save(tempPath + "\\capture.jpeg", ImageFormat.Jpeg);

                Console.WriteLine("Print capturada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
