using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Consumables
{
    public class WaterTownKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Town Key");
            Tooltip.SetDefault("Opens the path to the mysterious Water Town");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 20;
            item.noMelee = true;
            item.consumable = true;
            item.useTime = 20;
            item.useStyle = 4;
            //item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ForceRoar, 0);
            item.maxStack = 1;
            item.useAnimation = 20;
            item.value = Item.buyPrice(0, 5, 0, 0);
        }

        public override bool UseItem(Player player)
        {
            for (int x = 0; x < Main.maxTilesX; x++)
            {
                int y = ModContent.GetInstance<PrismWorld>().gatesY;
                Tile tile = Framing.GetTileSafely(x,y);
                if (tile.type == (ushort)ModContent.TileType<Tiles.Blox.UnbreakableGate>())
                {
                    tile.ClearTile();
                }
            }

            ModContent.GetInstance<PrismWorld>().accessedWaterTown = true;
            return true;
        }

    }
}