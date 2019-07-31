using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.NPCs
{
    class Boulduck : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boulduck");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Unicorn];
        }

        public override void SetDefaults()
        {
            npc.width =74;
            npc.height = 50;
            animationType = NPCID.Zombie;
            npc.aiStyle = 26;
            npc.lifeMax = 75;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 0.75f;
            npc.knockBackResist = 0.5f;
            npc.damage = 25;
            

        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance*0.1f;
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType("BoulduckFeather"), Main.rand.Next(3, 6));
        }


    }


}
