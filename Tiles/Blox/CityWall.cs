using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace prismmod.Tiles.Blox
{
    public class CityWall : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(74, 71, 245));
            mineResist = 7f;
            minPick = 100000000;
            
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 74/255;
            g = 71/255;
            b = 245/255;
        }
    }
}