/*using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.BossBags
{
    public class PrismachineBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Treasure Bag");
            Tooltip.SetDefault("Your Prismatic Loot Awaits You...");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.noMelee = true;
            item.consumable = true;
            item.useTime = 20;
            item.useStyle = 4;
            item.maxStack = 1;
            item.useAnimation = 15;
            item.expert = true;

        }

        public override void OpenBossBag(Player player)
        {
            int choice = Main.rand.Next(2/*n-1);
            //if(choice==0)
            //{ }
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override int BossBagNPC => mod.NPCType("Prismachine");
    }
}
*/