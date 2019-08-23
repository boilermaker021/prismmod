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
            DisplayName.SetDefault("Prismachine");
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
        private const int AI_Orbs_Spawned_Slot = 6;



        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;

        }

        public float AI_Timer {
            get => npc.ai[AI_Timer_Slot];
            set => npc.ai[AI_Timer_Slot] = value;

        }

        public float AI_Attack_Element1 {//use 0 to signify enabled attacks, and anything else to signify enabled attacks
            get => npc.ai[AI_Attack_Slot_Element1];
            set => npc.ai[AI_Attack_Slot_Element1] = value;

        }

        public float AI_Attack_Element2 {
            get => npc.ai[AI_Attack_Slot_Element2];
            set => npc.ai[AI_Attack_Slot_Element2] = value;

        }

        public float AI_Attack_Element3 {
            get => npc.ai[AI_Attack_Slot_Element3];
            set => npc.ai[AI_Attack_Slot_Element3] = value;

        }

        public float AI_Attack_Element4 {
            get => npc.ai[AI_Attack_Slot_Element4];
            set => npc.ai[AI_Attack_Slot_Element4] = value;

        }

        public float orbsSpawned{
            get=> npc.ai[AI_Orbs_Spawned_Slot];
            set=> npc.ai[AI_Orbs_Spawned_Slot] = value;

        }

        public override void AI()
        {

            if(orbsSpawned!=0)
            {
                //orb spawn code

            }

            if (npc.HasValidTarget&&npc.Center.X!=Main.player[npc.target].Center.X)//adjusts the X coordinate
            {
                float direction = (Main.player[npc.target].Center.X - npc.Center.X);
                direction = direction/Math.Abs(direction);
                npc.velocity.X=10f*direction;
            }
            else
            {
                npc.velocity.X=0f;//stops NPC's right<->left movement
            }

            if (npc.HasValidTarget&&npc.Center.Y<Main.player[npc.target].Center.Y+10f&&)npc.Center.Y<Main.player[npc.target].Center.Y+25f//adjusts the Y coordinate
            {
                float direction = (Main.player[npc.target].Center.Y - npc.Center.Y);
                direction = direction/Math.Abs(direction);
                npc.velocity.Y=10f*direction;
            }
            else
            {
                npc.velocity.Y=0f;//stops NPC's up<->down movement
            }

            //end of constant movement, attack orb functions start soon

            if(AI_Attack_Element1!=0)
            {
                //enable attacks of orb/element 1 type

            }

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
