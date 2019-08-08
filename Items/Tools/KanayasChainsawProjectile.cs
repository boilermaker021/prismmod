using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace prismmod.Items.Tools
{
	public class KanayasChainsawProjectile : ModProjectile
	{
		
		public override void SetDefaults()
		{
            projectile.Name = "Kanaya's Chainsaw";
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
		}

        /*public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            
            spriteBatch.Draw(mod.GetTexture("Items/Tools/KanayasLipstick"),
                  new Rectangle((int)position.X, (int)position.Y, (int)(14 * scale), (int)(36 * scale)),
                  drawColor);
            return false; 
        }*/

        /*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            short[] SeaCreatures = {NPCID.IcyMerman, NPCID.AnglerFish, NPCID.DukeFishron, NPCID.FlyingFish, NPCID.FungoFish,
            NPCID.Goldfish, NPCID.Piranha, NPCID.Shark, NPCID.PinkJellyfish, NPCID.SeaSnail, NPCID.BlueJellyfish,
            NPCID.GreenJellyfish, NPCID.BloodFeeder, NPCID.BloodJelly, NPCID.FungoFish, NPCID.CrimsonGoldfish, NPCID.CorruptGoldfish};
            foreach (short enemyType in SeaCreatures)
            {
                if (target.type == enemyType)
                {
                    damage *= 2;
                    break;
                }
            }
        }


    }
}
