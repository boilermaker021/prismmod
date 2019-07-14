using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace prismmod.NPCs
{
    class GargantuanTortoise : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gargantuan Tortoise");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantTortoise];
        }

        public override void SetDefaults()
        {
            npc.width = 75;
            npc.height = 51;
            npc.aiStyle = 39;
            npc.lifeMax = 750;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            animationType = NPCID.GiantTortoise;
            npc.value = 0.75f;
            npc.knockBackResist = 0.5f;
            npc.damage = 30;

        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.dayTime == false && mod.GetModWorld<PrismWorld>().killedGargantuanTortoise == false
                &&NPC.CountNPCS(mod.NPCType("GargantuanTortoise")) < 1)
            {
                return SpawnCondition.SurfaceJungle.Chance * 0.05f;
            }
            return 0f;
        }


        public override void NPCLoot()
        {
            if (mod.GetModWorld<PrismWorld>().killedGargantuanTortoise == false) ;
            {
                Item.NewItem(npc.getRect(), mod.ItemType("DuoGloriae"), 1);
            }
            mod.GetModWorld<PrismWorld>().killedGargantuanTortoise = true;
        }
    }
}
