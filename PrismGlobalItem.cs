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

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.NinjaHood || item.type == ItemID.NinjaPants)
            {
                item.defense = 1;
            }
            if (item.type == ItemID.NinjaShirt)
            {
                item.defense = 2;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.NinjaHood || item.type == ItemID.NinjaPants || item.type == ItemID.NinjaShirt)
            { 
                tooltips[3] = new TooltipLine(mod, "Tooltip4", "-10% Contact Damage \nDoes some other shit too, haven't decided yet");

            }
        }

        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "NinjaArmor")
            {
                player.setBonus = "Allows you to dash in any direction //MUST BE IMPLEMENTED AHHHHHHHHH";
                
            }
        }   

        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ItemID.NinjaHood||item.type == ItemID.NinjaPants|| item.type == ItemID.NinjaShirt)
            {
                if (item.type == ItemID.NinjaHood)
                {
                    player.thrownVelocity -= 0.15f;
                }
                player.GetModPlayer<PrismPlayer>().reducedContactDamage *= 1.10f;
            }
        }

    }
}
