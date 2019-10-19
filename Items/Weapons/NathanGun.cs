using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class NathanGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nathan's First Gun");
            Tooltip.SetDefault("This is a modded gun.");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            //Half of the time anything that is in the vanilla game is just spagetti filler code that is useless - Manamast
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}