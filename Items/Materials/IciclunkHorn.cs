using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

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