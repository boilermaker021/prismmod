using Terraria;
using Terraria.ModLoader;

namespace prismmod.NPCs.Prismachine
{
    public class PrismachineHomingBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismachine Homing Bolt");
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = false;
            projectile.ranged = true;
            projectile.timeLeft = 180;
            projectile.hostile = true;
            projectile.penetrate = 1;   
        }

        public override void AI()
        {
            for (int i= 0; i < Main.player.Length;i++)
            {
                Player target = Main.player[i];
                //If the npc is hostile
                if (target.Distance(projectile.Center)<400f)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (target.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }
    }
}