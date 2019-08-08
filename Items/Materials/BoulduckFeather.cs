using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Materials
{
    public class BoulduckFeather : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boulduck Feather");
            Tooltip.SetDefault("The feather of a Boulduck");
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