using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class TrekkersBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trekker's Boots");
            Tooltip.SetDefault("+5% Movement Speed");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 1;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("IciclunkHorn"), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}