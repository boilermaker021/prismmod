using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

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