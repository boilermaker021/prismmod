using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod
{
    internal class PrismmodHelper
    {
        Tile mcs = ModContent.TileType<Tiles.Blox.MoistChiseledStone>()
        string na = "nothing";

        //Building Section
        Tile[] exampleSquare = {//This array is currently set up to create a hollow 3x3 square of moist chiseled stone
            {mcs,mcs,mcs},
            {mcs,na,mcs},
            {mcs,mcs,mcs},
        };

        //other values
        string[] fishNames = { "Coral","Jerry","Mark","Bubbles","Octavius, Destroyer of Worlds",
        "Reefback", "Gerald", "Markus", "Vincent", "Tom", "Bofa", "Gex", "Salmonelly",
         "Jeb", "Joel", "[REDACTED]", "Guppy","Sharko","Natalie","Lance","Louie","Alph","Skinner",
         "Travis", "Joe", "Carl", "Smokey", "Toad", "Magnus", "Devin", "Blart"};

    }

}