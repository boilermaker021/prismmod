using Terraria;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class ShovelOfJusticeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shovel of Justice");
        }

        public override void SetDefaults()
        {
            projectile.Name = "Shovel of Justice";
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = 20;
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

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (player.GetModPlayer<PrismPlayer>().timesBounced < 5 && !player.HasBuff(mod.BuffType("NoBounce")))
            {
                player.velocity.Y = -10f;
                player.GetModPlayer<PrismPlayer>().timesBounced++;
            }

            if (player.GetModPlayer<PrismPlayer>().timesBounced == 5)
            {
                player.AddBuff(mod.BuffType("NoBounce"), 120);
                player.GetModPlayer<PrismPlayer>().timesBounced = 0;
            }
        }
    }
}