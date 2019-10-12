using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TrekkersMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trekker's Mask");
            Tooltip.SetDefault("+4% Bow Damage");
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
            player.GetModPlayer<PrismPlayer>().arrowDamageIncrease += 0.04f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("TrekkersJacket") && legs.type == mod.ItemType("TrekkersBoots");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Immunity to being Chilled, 15% chance for bows to freeze enemies";
            player.buffImmune[BuffID.Chilled] = true;
            player.GetModPlayer<PrismPlayer>().arrowsFreezeEnemies += 0.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpecialCloth"), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool DrawHead()
        {
            return true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
        }
    }
}