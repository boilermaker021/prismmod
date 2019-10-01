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
            //projectile.CloneDefaults(ProjectileID.Shuriken);
            // projectile.aiStyle = 3;
            //aiType = ProjectileID.Shuriken;
            //This is just easy vanilla AI for a shuriken
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = false;
            projectile.ranged = true;
        }
        public override void AI()
        {
            projectile.velocity.Y = projectile.velocity.Y + 0.3f;
        }

    }
}