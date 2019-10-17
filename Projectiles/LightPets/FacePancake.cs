using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace prismmod.Projectiles.LightPets
{
    public class FacePancake : ModProjectile
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
                modPlayer.facePancake = false;
            }
            if (modPlayer.facePancake)
            {
                projectile.timeLeft = 2;
            }

            float r = 148 / 255;
            float g = 255 / 255;
            float b = 86 / 255;

            float positionX = projectile.position.X + projectile.width / 2 - 33;
            float positionY = projectile.position.Y + projectile.height / 2 - 10;

            Vector2 npcPos = new Vector2(positionX, positionY);

            Lighting.AddLight(npcPos, r, g, b);
        }

       /* public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/LightPets/FacePancakeGlowmask");
            if (projectile.spriteDirection == 1)
            {
                texture = mod.GetTexture("Projectiles/LightPets/FacePancakeGlowmask");
            }
            if (projectile.spriteDirection == 0)
            {
                texture = mod.GetTexture("Projectiles/LightPets/FacePancakeGlowmaskR");
            }
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
                    projectile.position.Y - Main.screenPosition.Y + projectile.height - texture.Height * 0.5f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                projectile.rotation,
                texture.Size() * 0.5f,
                projectile.scale,
                SpriteEffects.None,
                0f
            );
        }*/

    }
}