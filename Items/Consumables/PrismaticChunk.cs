using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Consumables
{
    public class PrismaticChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Chunk");
            Tooltip.SetDefault("Summons the Bejeweled Behemoth");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 20;
            item.noMelee = true;
            item.consumable = true;
            item.useTime = 20;
            item.useStyle = 4;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ForceRoar, 0);
            item.maxStack = 20;
            item.useAnimation = 15;

        }

        public override bool UseItem(Player player)
        {
            //to be implemented when the Bejeweled Behemoth is coded.... in a million years
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.ZoneRockLayerHeight)
            {
                return true;
            }

            return false;
        }

        public override void AddRecipes()
        { 
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddIngredient(ItemID.Sapphire, 5);
            recipe.AddIngredient(ItemID.Ruby, 5);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddIngredient(ItemID.Diamond, 5);
            recipe.AddIngredient(ItemID.Amethyst, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

           
            

        }
    }
}