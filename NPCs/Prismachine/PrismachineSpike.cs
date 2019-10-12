using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.NPCs.Prismachine
{
    public class PrismachineSpike : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismachine Spike");
            //This is just easy vanilla AI for a shuriken
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 40;
            projectile.friendly = false;
            projectile.ranged = true;
            projectile.damage = 20;
            projectile.knockBack = 5;
            projectile.timeLeft = 180;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }
}