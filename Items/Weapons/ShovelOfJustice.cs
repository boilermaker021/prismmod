using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Weapons
{
	public class ShovelOfJustice : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shovel of Justice");
			Tooltip.SetDefault("Allows you to bounce when you hit enemies");
		}
		public override void SetDefaults()
		{
			item.damage = 5;
			item.melee = true;
			item.width = 100;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 15;
			item.useStyle = 3;
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (player.GetModPlayer<PrismPlayer>().timesBounced < 5 && !player.HasBuff(mod.BuffType("NoBounce")))
            {
                player.velocity.Y = -10f;
                player.GetModPlayer<PrismPlayer>().timesBounced++;
                
            }

            if (player.GetModPlayer<PrismPlayer>().timesBounced == 5)
            {
                player.AddBuff(mod.BuffType("NoBounce"), 120);
                player.GetModPlayer<PrismPlayer>().timesBounced = 0;
                
            }
        }
    }
}
