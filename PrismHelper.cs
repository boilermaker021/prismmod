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
                /*int yRoof=0;
                int h = (x + (width / 2));
                int k = (5);
                int cx = xStart;
                int cy = yStart + height;
                int a = (cy-k)/(x-h^2);
                yRoof = a*(x - h) ^ 2 + k;
                WorldGen.PlaceTile(x, yRoof, block);*/

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