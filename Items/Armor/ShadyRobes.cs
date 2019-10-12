using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ShadyRobes : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shady Robes");
            Tooltip.SetDefault("+10% Movement Speed");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 1;
            item.defense = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpecialCloth"), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.10f;
        }

        public override bool DrawHead()
        {
            return false;
        }
    }
}