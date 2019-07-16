using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace prismmod.NPCs
{
    [AutoloadBossHead]
    class GargantuanTortoise : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gargantuan Tortoise");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantTortoise];
        }

        public override void SetDefaults()
        {
            npc.width = 75;
            npc.height = 51;
            npc.aiStyle = 39;
            npc.lifeMax = 750;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            animationType = NPCID.GiantTortoise;
            npc.value = 0.75f;
            npc.knockBackResist = 0.5f;
            npc.damage = 30;
            banner = npc.type;
            bannerItem = mod.ItemType("GargantuanTortoiseBanner");

        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.dayTime == false && mod.GetModWorld<PrismWorld>().killedGargantuanTortoise == false
                &&NPC.CountNPCS(mod.NPCType("GargantuanTortoise")) < 1 &&NPC.downedSlimeKing)
            {
                return SpawnCondition.SurfaceJungle.Chance * 0.05f;
            }
            return 0f;
        }


        public override void NPCLoot()
        {
            if (mod.GetModWorld<PrismWorld>().killedGargantuanTortoise == false)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("DuoGloriae"));
            }
            mod.GetModWorld<PrismWorld>().killedGargantuanTortoise = true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            

            Texture2D texture = mod.GetTexture("NPCs/GargantuanTortoise_Glowmask");
            if (npc.spriteDirection==1)
            {
                texture = mod.GetTexture("NPCs/GargantuanTortoise_GlowmaskR");
            }
            if (npc.spriteDirection==0)
            {
                texture = mod.GetTexture("NPCs/GargantuanTortoise_Glowmask");
            }
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    npc.position.X - Main.screenPosition.X + npc.width * 0.5f,
                    npc.position.Y - Main.screenPosition.Y + npc.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                npc.rotation,
                texture.Size()*0.5f,
                npc.scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}
