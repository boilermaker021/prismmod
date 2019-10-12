using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.NPCs.Prismachine
{
    public class PrismachineFireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismachine Fireball");
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = false;
            projectile.ranged = true;
            projectile.damage = 20;
            projectile.knockBack = 5;
            projectile.timeLeft = 180;
            projectile.damage = 20;
        }

        public override void AI()
        {
            projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            if (projectile.velocity.Y > 10f)
            {
                projectile.velocity.Y = 16f;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }
}