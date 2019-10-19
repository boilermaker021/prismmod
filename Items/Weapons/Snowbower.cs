using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class Snowbower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowbower");
            Tooltip.SetDefault("Fires a volley of snowball arrows");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.width = 24;
            item.height = 42;
            item.maxStack = 1;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 12000;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("SnowballArrow");
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 7f;
            item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 newSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
            Projectile.NewProjectile(position.X, position.Y, newSpeed.X, newSpeed.Y, mod.ProjectileType("SnowballArrow"), damage, knockBack, player.whoAmI);
            return false;
        }
    }
}