using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod
{
    class PrismGlobalNPC : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Dryad)
            {
                if (ModContent.GetInstance<PrismWorld>().killedGargantuanTortoise)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Consumables.MechaEgg>());
                    nextSlot++;
                }
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Demon)
            {
                double chance = Main.rand.NextDouble();
                if (chance <= 0.005)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("CursedPan"), 1);
                }
            }
        }

    }
}
