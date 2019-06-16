using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections;


namespace prismmod.Projectiles
{
    public class MeekAcorn : ModProjectile
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
            projectile.velocity.Y = projectile.velocity.Y + 0.3f; // 0.1f for arrow gravity, 0.4f for knife gravity
        }
        

    }
}