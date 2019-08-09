using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Pets
{
	public class TinyTurtleCaptureOrb : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Capture Orb");
            Tooltip.SetDefault("Summons a Tiny Turtle to follow you");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.shoot = mod.ProjectileType("TinyTurtle");
            item.buffType = mod.BuffType("TinyTurtle");
        }


        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}
