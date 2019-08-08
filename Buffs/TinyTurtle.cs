using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Buffs
{
	public class TinyTurtle : ModBuff
	{
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Turtle Buddy!");
            Description.SetDefault("It yearns for freedom from the ball...");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<PrismPlayer>(mod).tinyTurtle = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("TinyTurtle")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("TinyTurtle"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }

    }
}
