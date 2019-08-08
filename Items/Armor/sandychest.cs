using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class Sandychest : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandy Robes");
        }
        public override void SetDefaults()
        {
            item.width = 11;
            item.height = 13;
            item.rare = 1;
            item.defense = 69;

        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpecialCloth"), 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override bool DrawHead()
        {
            return false;
        }
    }
}