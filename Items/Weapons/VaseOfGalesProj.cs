using Terraria;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class VaseOfGalesProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vase Of Gales");
        }

        public override void SetDefaults()
        {
            projectile.Name = "Vase Of Gales";
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = 84;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ownerHitCheck = true;
            projectile.magic = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //add logic for vaccum effect here - For Future Manamaster
            
        }
    }
}