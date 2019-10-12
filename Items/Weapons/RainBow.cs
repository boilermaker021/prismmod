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
            item.damage = 20;
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

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("AquaArrow"), damage, knockBack, player.whoAmI);
            return false;
        }
    }
}