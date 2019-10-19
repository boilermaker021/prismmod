using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace prismmod.Items.Weapons
{
    public class BoulducksRetribution : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boulducks Retribution");
            Tooltip.SetDefault("Quack.");
        }

        public override void SetDefaults()
        {
            item.damage = 5;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 0;
            item.value = 10000;
            item.rare = 2;
            item.shoot = mod.ProjectileType("BoulducksRetributionProjectile");
            item.shootSpeed = 7f;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.Duck, 0);
            item.autoReuse = false;
        }



    }
}