using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ShadyHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shady Hood");
            Tooltip.SetDefault("+1 Max Minion");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 1;
            item.defense = 1;
            
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ShadyTunic") && legs.type == mod.ItemType("ShadyRobes");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 Max Minions";
            player.maxMinions += 1;
        }

        public override bool DrawHead()
        {
            return false;
        }
    }
}