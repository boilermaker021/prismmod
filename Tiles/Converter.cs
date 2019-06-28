using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace prismmod.Tiles
{
    public class Converter : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new[] { 16,16};
            TileObjectData.newTile.Origin = new Point16(3, 1);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            ModTranslation name = CreateMapEntryName(); 
            name.SetDefault("Converter");
            AddMapEntry(new Color(200, 200, 200), name);
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.WorkBenches };
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
        }



        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("convertor"));
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            // 239,16,224
            Tile tile = Main.tile[i, j];
            if (tile.frameX == 0)
            {
                r = 0.93f;
                g = 0.06f;
                b = 0.87f;
            }
        }
    }
}
