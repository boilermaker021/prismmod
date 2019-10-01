using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod
{
    class PrismGlobalNPC : GlobalNPC
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
