using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Consumables
{
    public class DayLite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Day-Lite");
            Tooltip.SetDefault("Changes the time to Day.");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 20;
            item.noMelee = true;
            item.consumable = true;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item29;
            item.maxStack = 999;
            item.useAnimation = 30;

        }

        public override bool CanUseItem(Player player)
        {

            if (Main.dayTime == false)
            {
                Main.time = 10000;
                Main.dayTime = true;
                return true;

                
            }
            else
            {
                return false;
            }
        }

        public override bool UseItem(Player player)
        {
            return true;
        }
    }
}