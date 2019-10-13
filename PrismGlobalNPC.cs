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
    }
}