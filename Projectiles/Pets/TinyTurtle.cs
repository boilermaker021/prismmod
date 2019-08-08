using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections;


namespace prismmod.Projectiles.Pets
{
    public class TinyTurtle : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
            projectile.timeLeft = 1;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false; // Relic from aiType
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            PrismPlayer modPlayer = player.GetModPlayer<PrismPlayer>();
            if (player.dead)
            {
                modPlayer.tinyTurtle = false;
            }
            if (modPlayer.tinyTurtle)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}