using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace prismmod.Items.Tools
{
	public class KanayasChainsaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kanaya's Lipstick");
			Tooltip.SetDefault("Not just a stick of lipstick...");
		}
		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 54;
			item.height = 14;
			item.useTime = 7;
			item.useAnimation = 25;
            item.channel = true;
            item.noUseGraphic = true;
			item.useStyle = 5;
            item.noMelee = true;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item22;
			item.autoReuse = true;
            item.axe = 165;
            item.shoot = mod.ProjectileType("KanayasChainsawProjectile");
            item.shootSpeed = 40f;
		}

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            
            spriteBatch.Draw(mod.GetTexture("Items/Tools/KanayasLipstick"),
                  new Rectangle((int)position.X+10, (int)position.Y+10, (int)(14 * scale), (int)(36 * scale)),
                  drawColor);
            return false; 
        }

        /*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/


    }
}
