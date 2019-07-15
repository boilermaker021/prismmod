using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Materials
{
    public class DuoGloriae : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duo Gloriae");
            Tooltip.SetDefault("An emblem of fear and power");
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