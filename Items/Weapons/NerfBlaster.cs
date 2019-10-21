using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class Nerfblaster : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return !ModContent.GetInstance<ServerConfig>().DisableDevItems;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nerf Gun");
            Tooltip.SetDefault("It's Nerf or Nathan");
        }

        public override void SetDefaults()
        {
            item.damage = 69420;
            item.ranged = true;
            item.width = 33;
            item.height = 21;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 69;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Nerfdart");
            item.shootSpeed = 6f;
            item.useAmmo = mod.ItemType("Nerfdart");
            item.rare = -12;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }
    }
}