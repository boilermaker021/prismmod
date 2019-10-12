using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class ShovelOfJustice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shovel of Justice");
            Tooltip.SetDefault("Allows you to bounce when you hit enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 5;
            item.melee = true;
            item.width = 100;
            item.height = 20;
            item.useTime = 20;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.noMelee = true;
            item.channel = true;
            item.noUseGraphic = true;
            item.knockBack = 0;
            item.value = 10000;
            item.rare = 2;
            //item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("ShovelOfJusticeProj");
            item.shootSpeed = 40f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}