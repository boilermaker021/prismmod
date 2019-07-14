using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class TrekkersJacket : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trekker's Jacket");
            Tooltip.SetDefault("+3% Ranged Damage");
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
            player.rangedDamage += 0.03f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("IciclunkHorn"), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}