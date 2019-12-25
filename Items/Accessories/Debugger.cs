using Terraria;
using Terraria.ModLoader;

namespace prismmod.Items.Accessories
{
    public class Debugger : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return !ModContent.GetInstance<ServerConfig>().DisableDevItems;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Debugger");
            Tooltip.SetDefault("Doesn't do anything yet");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.defense = 0;
            item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

        }
    }
}