using Terraria;
using Terraria.ModLoader;

namespace prismmod.Items.Placeables
{
    class MoistChiseledStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moist Chiseled Stone");
            Tooltip.SetDefault("Can be placed");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Blox.MoistChiseledStone>();
        }
    }
}
