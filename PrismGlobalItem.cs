using System.Collections.Generic;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod
{
    class PrismGlobalItem : GlobalItem
    {
        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ItemID.NinjaHood||item.type == ItemID.NinjaPants)
            {
                item.defense = 1;
                player.GetModPlayer<PrismPlayer>().reducedContactDamage *= 1.10f;
            }
            if (item.type == ItemID.NinjaShirt)
            {
                item.defense = 2;
                player.GetModPlayer<PrismPlayer>().reducedContactDamage *= 1.10f;
            }
        }

    }
}
