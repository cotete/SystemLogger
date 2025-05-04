
using System;
using System.Windows.Forms;
using SystemLogger.Watchers;


namespace KeyMonitorApp
{
    internal class Program
    {


        static void Main(string[] args)
        {

            Program program = new Program();

            KeyboardAndMouse keyboardAndMouse = new KeyboardAndMouse();
            

            
            keyboardAndMouse.Start();

            Application.Run();

        }

    }
}