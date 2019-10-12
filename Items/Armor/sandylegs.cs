using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Sandylegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandy Boots");
        }

        public override void SetDefaults()
        {
            item.width = 7;
            item.height = 6;
            item.rare = 1;
            item.defense = 69;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpecialCloth"), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}