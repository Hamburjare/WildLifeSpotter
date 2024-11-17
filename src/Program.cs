using System;
using WildLifeSpotter.Services;

namespace WildLifeSpotter
{
    class Program
    {
        static void Main()
        {
            var spotter = new WildLifeSpotterService();
            spotter.Run();
        }
    }
}