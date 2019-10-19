using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using prismmod.Mounts;

namespace prismmod.Items.Mounts
{
    class PrismachinePowerCore: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismachine Power Code");
            Tooltip.SetDefault("<tooltip>");
        }

        public override void SetDefaults()
        {
            //use sound?
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = 30000;
            item.rare = -12;
            item.noMelee = true;
            item.mountType = MountType<ApatheticCloud>();
        }

    }
}
