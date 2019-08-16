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
        private const int AI_Timer_Slot = 1;


        private const int AI_State_Waiting = 0;
        private const int AI_State_Jumped = 1;
        private const int AI_State_Landed = 2;
        private int timer;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;

        }

        public float AI_Timer {
            get => npc.ai[AI_Timer_Slot];
            set => npc.ai[AI_Timer_Slot] = value;

        }

        public override void AI()
        {
            if (AI_State == AI_State_Waiting)
            {
                //move towards player
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 500f)
                {
                    npc.velocity = new Vector2(-10f, 4f); ;
                    AI_State = AI_State_Jumped;
                    AI_Timer = 0;

                }

                else if (AI_State == AI_State_Jumped)
                {
                    AI_Timer++;
                    npc.rotation = npc.velocity.ToRotation() + MathHelper.PiOver2;

                }


                else if (AI_State == AI_State_Landed)
                {

                    npc.rotation = 0.75f;

                    timer++;
                    if (timer > 120)
                    {
                        timer = 0;
                        AI_State = AI_State_Waiting;
                    }

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
