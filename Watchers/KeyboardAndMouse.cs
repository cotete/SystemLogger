using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogger.Watchers
{
    internal class KeyboardAndMouse
    {
        private static readonly string tempPath = System.IO.Path.GetTempPath();

        private IMouseEvents _MouseHook;

        private IKeyboardEvents _KeyboardHook;
        public KeyboardAndMouse()
        {

        }


        public void Start()
        {
            _KeyboardHook = Hook.GlobalEvents();
            _MouseHook = Hook.GlobalEvents();
            DetectCombinationsAndClicks();
            Console.WriteLine("Monitorando teclas e cliques Pressione ctrl+c para sair.");
        }

        public void DetectCombinationsAndClicks()
        {
            var map = new Dictionary<Combination, Action>{
                {Combination.FromString("Control+C"),()=>{Console.WriteLine("Control + C detectado!");
                                                          CaptureScreen(); } }
            };

            _MouseHook.MouseClick += (sender, e) =>
            {
                Console.WriteLine("Click Detected");
                CaptureScreen();
            };



            _KeyboardHook.OnCombination(map);
        }

        private void _MouseHook_MouseClick(object? sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _hook_KeyDown(object? sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void CaptureScreen()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap captureBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            
            captureBitmap.Save(tempPath+ "\\capture.jpeg", ImageFormat.Jpeg);

            Console.WriteLine("Print captured!");
        }

    }
}
