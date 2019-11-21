using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod.NPCs
{
    internal class FishPerson : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GoblinTinkerer];//107 if NPCID is incorrect
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 34;
            animationType = NPCID.GoblinTinkerer;
            npc.aiStyle = 7;
            npc.lifeMax = 75;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 0.75f;
            npc.knockBackResist = 0.5f;
            npc.damage = 14;
            npc.friendly=true;
        }
    }
}