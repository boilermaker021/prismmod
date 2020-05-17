using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace prismmod.NPCs
{
    internal class IciClunk : ModNPC
    {
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
            npc.netAlways = true;
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType("IciclunkHorn"), Main.rand.Next(3, 6));
        }

        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;
        private const int AI_Frame_Slot = 2;

        private const int AI_State_Waiting = 0;
        private const int AI_State_Jumped = 1;
        private const int AI_State_Movement = 2;
        private const int AI_State_Landed_PostMove = 3;
        private const int AI_State_Landed_PostJump = 4;
        private const int AI_State_Righting = 5;
        private bool jumped;
        private bool hitPlayer;

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

        public float AI_Frame
        {
            get => npc.ai[AI_Frame_Slot];
            set => npc.ai[AI_Frame_Slot] = value;
        }

        public float Rotation
        {
            get => npc.ai[3];
            set => npc.ai[3] = value;
        }

        public override void AI()
        {
            if (AI_State == AI_State_Waiting)
            {
                npc.rotation = 0f;
                jumped = false;
                hitPlayer = false;

                float adjDistance = (Main.player[npc.target].Center.X - npc.Center.X) * 0.0035f;
                //float adjDistanceY = Math.Abs((Main.player[npc.target].Center.Y - npc.Center.Y) * 0.001f);
                npc.TargetClosest();
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 500f)
                {
                    AI_Timer++;
                    if (AI_Timer % 35 == 0)
                    {
                        npc.velocity = new Vector2(20f * adjDistance, -20f);//*adjDistanceY);
                        jumped = true;
                        AI_State = AI_State_Jumped;
                        AI_Timer = 0;
                    }
                    else if (AI_Timer % 30 == 0)
                    {
                        AI_Frame = 4;
                    }
                    else if (AI_Timer % 20 == 0)
                    {
                        AI_Frame = 3;
                    }
                }
                else if (npc.HasValidTarget)
                {
                    AI_Timer++;
                    AI_Frame = 1;
                    if (AI_Timer % 20 == 0)
                    {
                        jumped = true;
                        npc.velocity = new Vector2(20f * (adjDistance * Math.Abs(1 / adjDistance)), -20f);//*adjDistanceY);
                        AI_State = AI_State_Movement;
                        AI_Timer = 0;
                    }
                }
            }
            else if (AI_State == AI_State_Movement)
            {
                AI_Frame = 2;
                npc.velocity.Y = npc.velocity.Y + 0.5f;

                if (npc.velocity.Y > 1f)
                {
                    jumped = false;
                }

                if (npc.velocity.Y < 1f && npc.velocity.Y > -1f && jumped == false)
                {
                    AI_State = AI_State_Landed_PostMove;
                }
            }
            else if (AI_State == AI_State_Jumped)
            {
                AI_Frame = 5;
                npc.velocity.Y = npc.velocity.Y + 0.5f; // 0.1f for arrow gravity, 0.4f for knife gravity
                if (npc.velocity.Y > 16f) // This check implements "terminal velocity".
                {
                    npc.velocity.Y = 16f;
                }
                npc.rotation = npc.velocity.ToRotation() + MathHelper.PiOver2;

                if (hitPlayer)
                {
                    AI_State = AI_State_Landed_PostMove;
                    npc.rotation = 0f;
                    hitPlayer = false;
                }

                if (npc.velocity.Y > 1f)
                {
                    jumped = false;
                }

                if (npc.velocity.Y < 1f && npc.velocity.Y > -1f && jumped == false)
                {
                    AI_State = AI_State_Landed_PostJump;
                    npc.rotation = MathHelper.Pi;
                }
            }
            else if (AI_State == AI_State_Landed_PostMove)
            {
                AI_Frame = 0;
                AI_Timer++;
                if (AI_Timer > 120)//waits for 2 seconds before the enemy rights itself
                {
                    AI_Timer = 0;
                    AI_State = AI_State_Waiting;
                }
            }
            else if (AI_State == AI_State_Landed_PostJump)
            {
                if (hitPlayer)
                {
                    AI_State = AI_State_Righting;
                    npc.rotation = 0f;
                    hitPlayer = false;
                    AI_Frame = 0;
                }
                else
                {
                    AI_Timer++;
                    if ((AI_Frame != 6 && AI_Frame != 7) || AI_Timer % 8 == 0)
                        if (AI_Frame == 6)
                        {
                            AI_Frame = 7;
                        }
                        else if (AI_Frame == 7)
                        {
                            AI_Frame = 6;
                        }
                        else
                        {
                            AI_Frame = 6;
                        }
                    if (AI_Timer > 180)//waits for 2 seconds before the enemy rights itself
                    {
                        AI_State = AI_State_Righting;
                        AI_Timer = 0;
                        jumped = true;
                        npc.velocity.Y = -6f;
                        npc.velocity.X = -2f;
                    }
                    npc.netUpdate = true;
                }
            }
            else if (AI_State == AI_State_Righting)
            {
                Main.NewText("Righting");
                AI_Frame = 0;
                
                if (npc.velocity.Y > 1f)
                {
                    jumped = false;
                }
                if (npc.velocity.Y < 1f && npc.velocity.Y > -1f && jumped == false)
                {
                    AI_State = AI_State_Landed_PostMove;
                    npc.rotation = 0f;
                }
                else
                {
                    npc.rotation = (npc.velocity.ToRotation() + MathHelper.PiOver2) - MathHelper.Pi;
                }
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (AI_State == AI_State_Jumped)
            {
                AI_State = AI_State_Righting;
                //npc.netUpdate = true;
                NetworkText text = NetworkText.FromLiteral("bruh");
                Color color = new Color(112, 202, 204);
                NetMessage.BroadcastChatMessage(text, color);
            }
        }

        public override void FindFrame(int frameHeight)
        {
            //add in frame-changing code depending on AI_State
            /*
            Frames:
            1.
            2.
            3.
            4.
            5.
            6.
            7.
            8.

            */
            npc.frame.Y = frameHeight * (int)AI_Frame;
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

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneSnow)
            {
                return SpawnCondition.Overworld.Chance * 0.1f;
            }
            else
            {
                return 0f;
            }
        }
    }
}