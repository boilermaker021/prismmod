using Terraria;
using Terraria.ModLoader;

namespace prismmod.Items.Accessories
{
    public class SupersonicPowerBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Supersonic Power Boots");
            Tooltip.SetDefault("Delete these now, you cheater");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.defense = 0;
            item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 20f;
            player.maxRunSpeed += 20f;
        }
    }
}