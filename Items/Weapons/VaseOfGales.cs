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
            item.ranged = false;
            item.width = 33;
            item.height = 22;
            item.useTime = 0;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = false;
            item.rare = 2;
            item.UseSound = SoundID.Item33;
            item.autoReuse = true;
            item.rare = -12;
            item.scale = 0.75f;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }
    }
}