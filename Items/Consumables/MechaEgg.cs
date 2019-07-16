using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Items.Consumables
{
    public class MechaEgg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("MechaEgg");
            Tooltip.SetDefault("Summons the Gargantuan Tortoise");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 20;
            item.noMelee = true;
            item.consumable = true;
            item.useTime = 15;
            item.useStyle = 4;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ForceRoar, 0);
            item.maxStack = 20;
            item.useAnimation = 15;
            item.value = Item.buyPrice(0, 5, 0, 0);

        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("GargantuanTortoise"));

            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.ZoneJungle&&NPC.CountNPCS(mod.NPCType("GargantuanTortoise"))<1)
            {
                return true;
            }

            return false;
        }

    }
}