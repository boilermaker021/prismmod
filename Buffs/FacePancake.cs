using Terraria;
using Terraria.ModLoader;

namespace prismmod.Buffs
{
    public class FacePancake : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Face Pancake");
            Description.SetDefault("An inescapable eldritch horror has been unleashed");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<PrismPlayer>().facePancake = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("FacePancake")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("FacePancake"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}