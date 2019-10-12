using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Accessories
{
    public class SharpshootersBadge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharpshooter's Badge");
            Tooltip.SetDefault("+5% Ranged Damage \n+5% Ranged Speed \n+10% chance to not consume ammo");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.defense = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage += 0.05f;
            player.GetModPlayer<PrismPlayer>().IncreaseBulletSpeed += 0.05f;
            player.GetModPlayer<PrismPlayer>().noAmmoUseChance = 0.10f;
        }

        public override float UseTimeMultiplier(Player player)
        {
            if (item.ranged)
            {
                return 1.05f;
            }
            else
            {
                return 1f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 5);
            recipe.AddIngredient(ItemID.MusketBall, 25);
            recipe.AddIngredient(ItemID.WoodenArrow, 25);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}