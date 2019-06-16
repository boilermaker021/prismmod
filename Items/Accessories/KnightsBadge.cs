using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Accessories
{
	public class KnightsBadge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Knight's Badge");
			Tooltip.SetDefault("+5% Melee Damage \n+5% Melee Speed");
		}
		public override void SetDefaults()
		{
            item.accessory = true;
            item.defense = 3;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.05f;
            player.meleeSpeed += 0.055f;
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
