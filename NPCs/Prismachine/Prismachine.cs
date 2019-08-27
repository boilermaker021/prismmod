using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace prismmod.NPCs.Prismachine
{
    class Prismachine : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Prismachine");
            Main.npcFrameCount[npc.type] = 9;
        }

        public override void SetDefaults()
        {
            //update hitbox to match sprite: KEEP HITBOX OUT OF ORB HITBOXES
            npc.width = 100;
            npc.height = 100;
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

        public float AI_Timer {
            get => npc.ai[AI_Timer_Slot];
            set => npc.ai[AI_Timer_Slot] = value;

        }

        public bool AI_Attack_Element1 {//use 0 to signify enabled attacks, and anything else to signify enabled attacks
            get => Attacks_Enabled[0];
            set => Attacks_Enabled[0] = value;

        }

        public bool Attack_Element1
        {//use 0 to signify enabled attacks, and anything else to signify enabled attacks
            get => Attacks_Enabled[0];
            set => Attacks_Enabled[0] = value;

        }

        public bool Attack_Element2
        {//use 0 to signify enabled attacks, and anything else to signify enabled attacks
            get => Attacks_Enabled[1];
            set => Attacks_Enabled[1] = value;

        }

        public bool Attack_Element3
        {//use 0 to signify enabled attacks, and anything else to signify enabled attacks
            get => Attacks_Enabled[2];
            set => Attacks_Enabled[2] = value;

        }

        public bool Attack_Element4
        {//use 0 to signify enabled attacks, and anything else to signify enabled attacks
            get => Attacks_Enabled[3];
            set => Attacks_Enabled[3] = value;

        }

        public override void AI()
        {
            

            if(!orbsSpawned&&Main.netMode!=1)
            {
                //orb spawn code

            }

            bool move = (Main.player[npc.target].Distance(npc.Center)<500f);

            if (move)
            {
                if (Main.netMode!=1&&timer==10)
                {
                    npc.velocity.X = (((float)generator.Next(0, 5) - 3) * 10f);
                    npc.velocity.Y = (((float)generator.Next(0, 5) - 3) * 10f);
                    npc.netUpdate = true;
                    timer = 0;
                }
            }

            //end of constant movement, attack orb functions start soon

            //if (AI_Attack_Element1!=0)
            //{
            //enable attacks of orb/element 1 type

            //}
            timer++;
        }

        public override void FindFrame(int frameHeight)//?
        {
            npc.frame.Y = 0;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                //Re-add once Prismachine gores have been entered
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Prismachine"), 1f);
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Prismachine2"), 1f);
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Prismachine3"), 1f);
            }
        }
    }
}
