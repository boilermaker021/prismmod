using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;


namespace prismmod.NPCs.Prismachine
{
    [AutoloadBossHead]
    class Prismachine : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Prismachine");
            Main.npcFrameCount[npc.type] = 21;
        }

        public override void SetDefaults()
        {
            //update hitbox to match sprite: KEEP HITBOX OUT OF ORB HITBOXES
            npc.width = 364;
            npc.height = 260;
            //no Ai Style
            npc.lifeMax = 5000; //ask braden for life values
            //beware of generic hit sounds
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //?npc.value = 0.75f;
            npc.knockBackResist = 1f;
            npc.damage = 1000; //lots of damage, should not get close to it, bceeause it should not get close to you
            // npc.immune = false;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.boss = true;
        }


        //on spawn method, spawn orbs around the battlefied. Ask braden for range restrictions

        public override void NPCLoot()
        {
            //Change loot to bossbag in hard mode and regular items if not
            //Item.NewItem(npc.getRect(), ItemID.Diamond, Main.rand.Next(3, 6));
        }


        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;
        private const int AI_Attack_Slot_Element1 = 2;
        private const int AI_Attack_Slot_Element2 = 3;
        private const int AI_Attack_Slot_Element3 = 4;
        private const int AI_Attack_Slot_Element4 = 5;
        private bool orbsSpawned = false;
        private bool[] Attacks_Enabled = { false, false, false, false };
        private Random generator = new Random();
        private int timer = 1;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;

        }

        public float AI_Timer
        {
            get => npc.ai[AI_Timer_Slot];
            set => npc.ai[AI_Timer_Slot] = value;

        }

        public bool MasterPump
        {
            get => Attacks_Enabled[0];
            set => Attacks_Enabled[0] = value;

        }

        public bool CrystallizedTelepathy
        {
            get => Attacks_Enabled[1];
            set => Attacks_Enabled[1] = value;

        }

        public bool FlareCannon
        {
            get => Attacks_Enabled[2];
            set => Attacks_Enabled[2] = value;

        }

        public bool SpikeSpreader
        {
            get => Attacks_Enabled[3];
            set => Attacks_Enabled[3] = value;

        }

        public int numOfAttacks()
        {
            int t = 0;
            foreach (bool b in Attacks_Enabled)
            {
                if (b)
                {
                    t++;
                }
            }
            return t;
        }


        public bool[] attackSetter()
        {
            int attackNum = (int)npc.ai[0];
            bool[] parsedAttackList = new bool[4];
            if ((int)(attackNum / 1000) == 1)
            {
                parsedAttackList[0] = true;
                attackNum -= 1000;
            }
            if ((int)(attackNum / 100) == 1)
            {
                parsedAttackList[1] = true;
                attackNum -= 100;
            }
            if ((int)(attackNum / 10) == 1)
            {
                parsedAttackList[2] = true;
                attackNum -= 10;
            }
            if ((int)(attackNum) == 1)
            {
                parsedAttackList[3] = true;
            }
            return parsedAttackList;
        }

        public override void AI()
        {

            Attacks_Enabled = attackSetter();

            if (!orbsSpawned && Main.netMode != 1)
            {
                //orb spawn code
                for (int i = 0; i < 4; i++)
                {
                    int orb = NPC.NewNPC((int)npc.position.X+(i*20), (int)npc.position.Y+(i*20), mod.NPCType("Orb"));
                    Main.npc[orb].ai[0] = npc.whoAmI;
                    Main.npc[orb].ai[1] = i;
                    Main.npc[orb].ai[2] = 0;
                }
                orbsSpawned = true;
            }


            npc.velocity.X = 0f;
            npc.velocity.Y = 0f;
            /*if (Main.player[npc.target].Distance(npc.Center) < 500f)
            {
                if (Main.netMode != 1 && timer >= 10)
                {
                    npc.velocity.X = (((float)generator.Next(0, 5) - 3) * 10f);
                    npc.velocity.Y = (((float)generator.Next(0, 5) - 3) * 10f);
                    npc.netUpdate = true;
                    timer = 0;
                }
            }*/


            if (MasterPump)
            {
                //enable attacks of orb/element 1 type

            }
            if (CrystallizedTelepathy)
            {
                //enable attacks of orb/element 2 type

            }
            if (FlareCannon)
            {
                //enable attacks of orb/element 3 type

            }
            if (SpikeSpreader)
            {
                //enable attacks of orb/element 4 type

            }
            timer++;
        }

        int frame_timer = 0;
        public override void FindFrame(int frameHeight)//Learn how to do this you lazy bastard
        {
            npc.frame.Y = frameHeight * (int)(frame_timer/10);
            frame_timer++;
            if (frame_timer > 200)
            {
                frame_timer = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore5"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore6"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore7"), 1f);
            }
        }
    }
}
