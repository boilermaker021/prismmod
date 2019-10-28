using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class VanquishersHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vanquisher's Helmet");
            Tooltip.SetDefault("???");
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
            ///update equip for armor
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("VanquishersChestplate") && legs.type == mod.ItemType("VanquishersGreaves");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.GetModPlayer<PrismPlayer>().vertDash = true;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpecialCloth"), 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

        public override bool DrawHead()
        {
            return false;
        }
    }
}