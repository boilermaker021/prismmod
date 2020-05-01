using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace prismmod.Buffs
{
    public class ApatheticCloud : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cloud Mount");
            Description.SetDefault("<Buff Description>");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(MountType<Mounts.ApatheticCloud>(), player);
            player.buffTime[buffIndex] = 10;
            player.mount.ResetFlightTime(0f);
        }
    }
}