using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;


namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TrekkersHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trekker's Headgear");
            Tooltip.SetDefault("+4% Rocket Damage");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 1;
            item.defense = 3; 
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<PrismPlayer>().rocketDamageIncrease += 0.04f;
            
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("TrekkersJacket") && legs.type == mod.ItemType("TrekkersBoots");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Immunity to being Chilled, Blast Radius increased by 25%";
            player.buffImmune[BuffID.Chilled] = true;
            //Blast radius buff by 25%, will be implemented later
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