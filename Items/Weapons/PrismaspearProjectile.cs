using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace prismmod.Items.Weapons
{
    public class PrismaspearProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismaspear");
        }

        public override void SetDefaults()
        {
            projectile.Name = "Prismaspear";
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
        }

        public override void AI()
        {
        }

    }
}