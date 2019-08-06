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
            npc.width =18;
            npc.height = 34;
            //npc.aiStyle = 41;
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
        
        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;

        }
        public override void AI()
        {
            
        }

        public override void FindFrame(int frameHeight)
        {

            npc.frame.Y = 0;
        }

    }


}
