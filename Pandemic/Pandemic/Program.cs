using System;

namespace Pandemic
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (PandemicGame game = new PandemicGame())
            {
                game.Run();
            }
        }
    }
#endif
}

