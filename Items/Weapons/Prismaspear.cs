using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Weapons
{
    public class Prismaspear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismaspear");
            Tooltip.SetDefault("Lowers enemy defense by 50% for 7 seconds");
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.width = 90;
            item.height = 90;
            item.useTime = 24;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;

            item.shootSpeed = 40f;
            item.shoot = ModContent.ProjectileType<PrismaspearProjectile>();
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