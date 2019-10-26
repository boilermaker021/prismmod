using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TrekkersHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trekker's Hood");
            Tooltip.SetDefault("+4% Flamethrower Damage");
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
            player.GetModPlayer<PrismPlayer>().flamerDamageIncrease += 0.04f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("TrekkersJacket") && legs.type == mod.ItemType("TrekkersBoots");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Immunity to being Chilled, flamethrower flames reach 25% further";
            player.buffImmune[BuffID.Chilled] = true;
            player.GetModPlayer<PrismPlayer>().flamerSpeedIncrease += 0.25f;
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