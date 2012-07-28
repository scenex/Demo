using System;

namespace Metaballs
{
    using global::Metaballs.Metaballs;

#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Metaballs3D game = new Metaballs3D())
            {
                game.Run();
            }
        }
    }
#endif
}

