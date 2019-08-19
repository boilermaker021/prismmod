using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.NPCs.Projectile
{
    class Prismachine : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismachine");
            Main.npcFrameCount[npc.type] = 9;
        }

        public override void SetDefaults()
        {
            npc.width =;
            npc.height = 34;
            animationType = NPCID.Zombie;
            //no Ai Style
            npc.lifeMax = 5000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //?npc.value = 0.75f;
            npc.knockBackResist = 1f;
            npc.damage = 100;

        }


        public override void NPCLoot()
        {
            //Change loot to bossbag in hard mode and regular items if not
            //Item.NewItem(npc.getRect(), ItemID.Diamond, Main.rand.Next(3, 6));
        }

        public override void AI()
        {
            //start working on AI

        }

        public override void FindFrame(int frameHeight)//?
        {


        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                //Readd once Prismachine gores have been entered
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DiamondZombieGore1"), 1f);
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DiamondZombieGore2"), 1f);
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DiamondZombieGore3"), 1f);
            }
        }
    }
}
