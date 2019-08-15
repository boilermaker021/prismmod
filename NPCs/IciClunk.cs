using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.NPCs
{
    class IciClunk : ModNPC
    {

        Player player;
        private float speed;


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iciclunk");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.width =100;
            npc.height = 108;
            //no aiStyle
            npc.lifeMax = 75;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 0.75f;
            npc.knockBackResist= 0.5f;

        }



        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType("IciclunkHorn"), Main.rand.Next(3, 6));
        }


        private const int AI_State_Slot = 0;
        private const int AI_State_Waiting = 0;
        private const int AI_State_Jumping = 1;
        private const int AI_State_Air = 2;
        private const int AI_State_Landed = 3;
        private int timer;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;

        }

        public override void AI()
        {
            if(AI_State == AI_State_Waiting)
            {
                //move towards player
                //check player distance
               // {


                //}

            }

            else if(AI_State == AI_State_Jumping)
            {


            }

            else if(AI_State == AI_State_Air)
            {


            }

            else if(AI_State == AI_State_Landed)
            {

                //maintain sprite rotation
                timer++;
                if(timer>20)
                {
                    timer=0;
                    AI_State = AI_State_Waiting;
                }

            }


        }

        public override void FindFrame(int frameHeight)
        {

            npc.frame.Y = 0;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IciclunkGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IciclunkGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IciclunkGore3"), 1f);
            }
        }

    }


}
