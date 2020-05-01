using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Consumables
{
    public class NightLite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Night-Lite");
            Tooltip.SetDefault("Changes the time to Night.");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 20;
            item.noMelee = true;
            item.consumable = true;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item29;
            item.maxStack = 999;
            item.useAnimation = 30;
        }

        public override bool CanUseItem(Player player)
        {
            if (Main.dayTime == true)
            {
                Main.time = 0;
                Main.dayTime = false;
                return true;
            }
            return false;
        }

        public override bool UseItem(Player player)
        {
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ItemID.DemoniteBar, 5);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 5);
            recipe2.AddIngredient(ItemID.FallenStar, 3);
            recipe2.SetResult(this, 3);
            recipe2.AddRecipe();
        }
    }
}