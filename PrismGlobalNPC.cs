using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod
{
    internal class PrismGlobalNPC : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Dryad)
            {
                if (mod.GetModWorld<PrismWorld>().killedGargantuanTortoise)
                {
                    shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Consumables.MechaEgg>());
                    nextSlot++;
                }
            }
        }
    }
}