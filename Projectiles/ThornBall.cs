using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections;


namespace prismmod.Projectiles
{
    public class ThornBall : ModProjectile
    {

        public override void SetDefaults()
        {
            
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 600;

        }

        public override void AI()
        {
            projectile.velocity.Y = projectile.velocity.Y + 0.2f; // 0.1f for arrow gravity, 0.4f for knife gravity
            if (projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
            {
                projectile.velocity.Y = 16f;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
        
            projectile.velocity = new Vector2(0f);
            return false;

        }

    }
}