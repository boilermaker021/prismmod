using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace prismmod.NPCs
{
    class Edgar : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Edgar");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.width = 75;
            npc.height = 51;
            npc.aiStyle = 22;
            npc.lifeMax = 40;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            animationType = NPCID.Wraith;
            npc.value = 0.75f;
            npc.knockBackResist = 0.5f;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.damage = 10;

        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
        }


        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/Edgar_Glowmask");
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
