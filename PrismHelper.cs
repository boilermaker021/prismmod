using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod
{
    public class PrismHelper
    {
        public static int mcs = 1;
        public static int ctwl = 2;

        public static int[,] testHouse = {

            {mcs, mcs, mcs},
            {mcs, ctwl, mcs},
            {mcs, mcs, mcs}
        };

        public static void drawBaseFishHouse(int xStart, int yStart, int height, int width, int block)
        {
            for (int x = xStart; x < xStart + width; x++)
            {
                for (int y = yStart; y > yStart-height; y--)
                {
                    if (x == xStart || x == xStart + width-1 || y == yStart || y == yStart - height+1)
                    {
                        WorldGen.PlaceTile(x, y, block);
                    }
                }
                int y=0;

                WorldGen.PlaceTile(x, y, block);

            }


        }

        //Building Section

        //other values
        public static string[] fishNames = { "Coral","Jerry","Mark","Bubbles","Octavius, Destroyer of Worlds",
        "Reefback", "Gerald", "Markus", "Vincent", "Tom", "Bofa", "Gex", "Salmonelly",
         "Jeb", "Joel", "[REDACTED]", "Guppy","Sharko","Natalie","Lance","Louie","Alph","Skinner",
         "Travis", "Joe", "Carl", "Smokey", "Toad", "Magnus", "Devin", "Blart"};

    }

}