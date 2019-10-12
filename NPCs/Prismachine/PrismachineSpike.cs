using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace prismmod.NPCs.Prismachine
{
    public class PrismachineSpike : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismachine Spike");
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = false;
            projectile.ranged = true;
            projectile.timeLeft = 180;
            projectile.hostile = true;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}