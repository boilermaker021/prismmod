using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace prismmod.NPCs.Prismachine
{
    [AutoloadBossHead]
    partial class Prismachine : ModNPC
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
            //code placed elsewhere//npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //?npc.value = 0.75f;
            npc.knockBackResist = 1f;
            npc.damage = 1000; //lots of damage, should not get close to it, bceeause it should not get close to you
            // npc.immune = false;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.boss = true;
            npc.dontTakeDamageFromHostiles = true;
            bossBag = mod.ItemType("PrismachineBag");

            Mod musicmod = ModLoader.GetMod("prismmodmusic");
            if(musicmod!=null)
            {
                musicPriority = MusicPriority.BossLow;
                music = musicmod.GetSoundSlot(SoundType.Music, "Sounds/Music/PrismachineTheme");
            }

            
        }

        //on spawn method, spawn orbs around the battlefied. Ask braden for range restrictions

        public override void NPCLoot()
        {
            //Change loot to bossbag in hard mode and regular items if not
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            Item.NewItem(npc.getRect(), ItemID.IronBar, 10);
            Item.NewItem(npc.getRect(), ItemID.SilverBar, 10);
            Item.NewItem(npc.getRect(), ItemID.PlatinumBar, 10);

            ModContent.GetInstance<PrismWorld>().downedPrismachine = true;
        }

        private const int AI_State_Slot = 2;
        private const int AI_Timer_Slot = 1;
        private bool GenNewAttack = false;
        private int attackTimes = 0;
        private bool orbsSpawned = false;
        private bool[] Attacks_Enabled = { false, false, false, false };

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

        private int tAttacks = 0;
        public override void AI()
        {
            npc.spriteDirection = 0;
            if (tAttacks == 0 &&numOfAttacks() ==1 )
            {
                GenNewAttack = true;
            }
            tAttacks = numOfAttacks();
            

            Attacks_Enabled = attackSetter();
            if (GenNewAttack)
            {
                GenNewAttack = false;
                attackTimes = 0;
                AI_State = Main.rand.Next(4)+1;
                while (Attacks_Enabled[(int)AI_State-1] == false)
                {
                    AI_State = Main.rand.Next(4)+1;
                }
                //Main.NewText("New attack #: " + AI_State);
            }

            if (!orbsSpawned && Main.netMode != 1)
            {
                int numX = 0;
                int numY = 0;
                //orb spawn code
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        numX = 1;
                        numY = 1;
                    }
                    else if (i == 1)
                    {
                        numX = -1;
                        numY = -1;
                    }
                    else if (i == 2)
                    {
                        numX = 1;
                        numY = -1;
                    }
                    else if (i == 3)
                    {
                        numX = -1;
                        numY = 1;
                    }
                    int orb = NPC.NewNPC((int)npc.Center.X + (numX * 250), (int)npc.Center.Y + (numY * 250), mod.NPCType("Orb"));
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

            if (MasterPump & AI_Timer % 30 == 0 & Main.netMode != 1 && AI_State == 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y + (npc.height / 2), 0f, 10f, ModContent.ProjectileType<PrismachineDroplet>(), 20, 1.5f);
                if (attackTimes >= 6)
                {
                    GenNewAttack = true;
                }
                attackTimes++;
            }
            if (CrystallizedTelepathy & AI_Timer % 60 == 0 & Main.netMode != 1 & AI_State == 2)
            {   //down
                Projectile.NewProjectile(npc.Center.X + (npc.width / 8), npc.Center.Y - (npc.height / 18), 0f, 10f, ModContent.ProjectileType<PrismachineHomingBolt>(), 20, 1.5f);
                Projectile.NewProjectile(npc.Center.X - (npc.width / 8), npc.Center.Y - (npc.height / 18), 0f, 10f, ModContent.ProjectileType<PrismachineHomingBolt>(), 20, 1.5f);
                //up-right
                Projectile.NewProjectile(npc.Center.X + (npc.width / 8), npc.Center.Y - (npc.height / 18), 5f, -5f, ModContent.ProjectileType<PrismachineHomingBolt>(), 20, 1.5f);
                Projectile.NewProjectile(npc.Center.X - (npc.width / 8), npc.Center.Y - (npc.height / 18), 5f, -5f, ModContent.ProjectileType<PrismachineHomingBolt>(), 20, 1.5f);
                //up-left
                Projectile.NewProjectile(npc.Center.X + (npc.width / 8), npc.Center.Y - (npc.height / 18), -5f, -5f, ModContent.ProjectileType<PrismachineHomingBolt>(), 20, 1.5f);
                Projectile.NewProjectile(npc.Center.X - (npc.width / 8), npc.Center.Y - (npc.height / 18), -5f, -5f, ModContent.ProjectileType<PrismachineHomingBolt>(), 20, 1.5f);

                if (attackTimes >= 0)
                {
                    GenNewAttack = true;
                }
                attackTimes++;
            }
            if (FlareCannon & AI_Timer % 7 == 0 & Main.netMode != 1 & AI_State == 3)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y - (npc.height / 2), ((float)Main.rand.Next(11) - 5), -8f, ModContent.ProjectileType<PrismachineFireball>(), 20, 1.5f);

                if (attackTimes >= 59)
                {
                    GenNewAttack = true;
                }
                attackTimes++;
            }
            if (SpikeSpreader & AI_Timer % 60 == 0 & Main.netMode != 1 & AI_State == 4)//change time intervals
            {
                int times = 8;//change this value for number of spikes
                //left
                for (int i = 0; i < times; i++)
                {
                    Projectile.NewProjectile(npc.Left.X + 5f, npc.Center.Y + 20f, -10f, ((float)-times / 4) + i * 2, ModContent.ProjectileType<PrismachineSpike>(), 20, 1.5f);
                }

                //right
                for (int i = 0; i < times; i++)
                {
                    Projectile.NewProjectile(npc.Right.X - 5f, npc.Center.Y + 20f, 10f, ((float)-times / 4) + i * 2, ModContent.ProjectileType<PrismachineSpike>(), 20, 1.5f);
                }
                
                if (attackTimes >= 2)
                {
                    GenNewAttack = true;
                }
                attackTimes++;
                //enables attacks of orb/element 4 type
            }
            AI_Timer++;
            //Main.NewText("Timer: "+AI_Timer);
            if (AI_Timer >= 61)
            {
                AI_Timer = 1;
            }
            
        }

        private int frame_timer = 0;
        private int frameNumber = 0;
        private int count = 0;

        bool start = false;
        public override void FindFrame(int frameHeight)//Learn how to do this you lazy bastard
        {
            npc.frame.Y = frameHeight * frameNumber;
            if (AI_State == 1)
            {

                if (AI_Timer%25==0)
                {
                    count = 0;
                    start = true;
                }

                if (start == true)
                {
                    frameNumber = 15 + count;
                    count++;
                }
                if (count > 5)
                {
                    count = 0;
                    start = false;
                }
            }
            else if (AI_State == 2)
            {
                if (AI_Timer % 58 == 0)
                {
                    count = 0;
                    start = true;
                }

                if (start == true)
                {
                    frameNumber = 7 + count;
                    count++;
                }
                if (count > 1)
                {
                    count = 2;
                    start = false;
                    frameNumber = 8;
                }
            }
            else if (AI_State == 3)
            {
                if (start == false)
                {
                    count = 0;
                    start = true;
                }

                if (start == true)
                {
                    frameNumber = 1 + count;
                    count++;
                }
                if (count > 4)
                {
                    count = 5;
                }
            }
            else if (AI_State == 4)
            {
                if (AI_Timer%55==0)
                {
                    count = 0;
                    start = true;
                }

                if (start == true)
                {
                    frameNumber = 9 + count;
                    count++;
                }
                if (count > 5)
                {
                    count = 0;
                    start = false;
                }
            }
            else {
                frameNumber = 0;
            
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life > 0)
            {
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Prismachine/zzzt.wav"));
                // Note to future self try to find out how to randomize pitch changes.
            }
            // Plays a custom sound when hit and above 0 health
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore1"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore2"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore3"), 1f);
                // Add death sound here
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore4"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore5"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore6"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PrismachineGore7"), 1f);
            }
        }
    }
}