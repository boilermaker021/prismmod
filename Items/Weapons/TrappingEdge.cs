using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class TrappingEdge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trapping Edge");
            Tooltip.SetDefault("Freezes enemies while they are being stabbed.");
        }

        public override void SetDefaults()
        {
            item.damage = 5;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 10;
            item.useStyle = 3;
            item.knockBack = 0;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knoclkback, bool crit)
        {
            target.AddBuff(mod.BuffType("Freezing"), 60);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddIngredient(ItemID.Stinger, 1);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddIngredient(ItemID.PlatinumBar, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}