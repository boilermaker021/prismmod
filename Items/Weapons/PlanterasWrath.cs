using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class PlanterasWrath : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantera's Wrath");
            Tooltip.SetDefault("Launches weighted thorn balls");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.magic = true;
            item.mana = 12;
            item.width = 40;
            item.height = 40;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ThornBall");
            item.shootSpeed = 13f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(mod.TileType("ExampleWorkbench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
}
}