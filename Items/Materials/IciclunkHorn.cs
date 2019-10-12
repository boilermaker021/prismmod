using Terraria;
using Terraria.ModLoader;

namespace prismmod.Items.Materials
{
    public class IciclunkHorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iciclunk Horn");
            Tooltip.SetDefault("The horn of an Iciclunk");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
        }

        public override bool CanUseItem(Player player)
        {
            return false;
        }
    }
}