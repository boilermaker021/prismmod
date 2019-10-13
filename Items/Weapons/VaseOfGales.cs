using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class VaseOfGales : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vase Of Gales");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.width = 33;
            item.height = 22;
            item.useTime = 0;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = false;
            item.rare = 2;
            item.UseSound = SoundID.Item33;
            item.autoReuse = true;
            item.rare = 2;
            item.scale = 0.75f;
            item.magic = true;
            item.mana = 1;
            item.shoot = mod.ProjectileType("VaseOfGalesProj");
            item.shootSpeed = 100f;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }
    }
}