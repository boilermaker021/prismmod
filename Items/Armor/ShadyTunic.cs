using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ShadyTunic : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shady Tunic");
            Tooltip.SetDefault("+5% Summon Damage");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 1;
            item.defense = 1;
            
        }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.05f;
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