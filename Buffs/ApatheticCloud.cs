using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
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
            //Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

        }
    }
}