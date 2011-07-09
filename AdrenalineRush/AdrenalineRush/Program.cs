using System;
using System.Windows.Forms;

namespace AdrenalineRush
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main(string[] args)
        //{
        //    Application.Run(new StartupScreen());
        //}

        static void Main(string[] args)
        {
            using (Demo demo = new Demo())
            {
                demo.Run();
            }
        }
    }
#endif
}

