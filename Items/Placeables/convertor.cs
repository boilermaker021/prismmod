using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Placeables
{
    public class convertor : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Converts items and ores");
            DisplayName.SetDefault("Converter");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("Converter");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WorkBench);
            recipe.AddIngredient(ItemID.Furnace, 2);
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddIngredient(ItemID.Amethyst, 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}