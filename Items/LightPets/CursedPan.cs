using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.LightPets
{
    public class CursedPan : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Pan");
            Tooltip.SetDefault("You don't want to do this...");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.shoot = mod.ProjectileType("FacePancake");
            item.buffType = mod.BuffType("FacePancake");
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