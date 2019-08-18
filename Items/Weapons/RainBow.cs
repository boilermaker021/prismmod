using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class RainBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rain Bow");
            Tooltip.SetDefault("Moistens your enemies.");
        }

        public override void SetDefaults()
        {
            item.damage = 2000;
            item.ranged = true;
            item.width = 12;
            item.height = 38;
            item.maxStack = 1;
            item.useTime = 56;
            item.useAnimation = 56;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 12000;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("AquaArrow");
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 7f;
            item.autoReuse = true;
        }
    }
}