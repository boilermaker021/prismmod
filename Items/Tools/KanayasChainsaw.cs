using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.Items.Tools
{
    public class KanayasChainsaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mysterious Lipstick");
            Tooltip.SetDefault("Not just a stick of lipstick... \nDoes double damage to sea creatures");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
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
            item.axe = 220;
            item.shoot = mod.ProjectileType("KanayasChainsawProjectile");
            item.shootSpeed = 40f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
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