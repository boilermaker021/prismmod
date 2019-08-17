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
            npc.width = 100;
            npc.height = 108;
            //no aiStyle
            npc.damage = 10;
            npc.lifeMax = 75;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 0.75f;
            npc.knockBackResist = 0.5f;

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
                npc.rotation = 0;

                //insert move towards player code
                //currently, the enemy does not walk
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 500f)
                {
                    npc.velocity = new Vector2(-20f, -20f); ;
                    AI_State = AI_State_Jumped;
                    AI_Timer = 0;

                }
            }

            else if (AI_State == AI_State_Jumped)
            {
                npc.velocity.Y = npc.velocity.Y + 0.2f; // 0.1f for arrow gravity, 0.4f for knife gravity
                if (npc.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
                {
                    npc.velocity.Y = 16f;
                }
                npc.rotation = npc.velocity.ToRotation() + MathHelper.PiOver2;

            }


            /*else if (AI_State == AI_State_Landed)
            {

                npc.rotation = 0.75f;//points sprite downwards

                timer++;
                if (timer > 120)//waits for 2 seconds before the enemy rights itself
                {
                    timer = 0;
                    AI_State = AI_State_Waiting;
                    npc.rotation = 0f;//resets rotation
                }

            }*/

        }
        public override void FindFrame(int frameHeight)
        {
            //add in frame-changing code depending on AI_State
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