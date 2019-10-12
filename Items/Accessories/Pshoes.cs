using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Accessories
{
    public class Pshoes : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pshooooes");
            Tooltip.SetDefault("Don't you dare visit your denizen early");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.canRocket = true;
            player.rocketBoots = 1;
            //player.rocketTime = 240;
            player.rocketTimeMax = 24;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 5);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}