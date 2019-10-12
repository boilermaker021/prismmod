using Terraria;
using Terraria.ModLoader;

namespace prismmod.Items.Materials
{
    public class SpecialCloth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Special Cloth");
            Tooltip.SetDefault("A special kind of cloth");
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