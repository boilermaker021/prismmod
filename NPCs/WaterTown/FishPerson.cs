using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static prismmod.PrismHelper;

namespace prismmod.NPCs.WaterTown
{
    internal class FishPerson : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fish Person");
            Main.npcFrameCount[npc.type] = 16;//107 if NPCID is incorrect
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.width = 32;
            npc.height = 52;
            animationType = NPCID.GoblinTinkerer;
            npc.aiStyle = 7;
            npc.lifeMax = 75;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 0.75f;
            npc.knockBackResist = 0.5f;
            npc.damage = 14;
            npc.friendly=true;
        }

        public override void AI()
        {
            //breathe underwater, do not override.
            npc.breath = 100;
            npc.breathCounter = 100;
        }

        public override string TownNPCName()
        {
            if(this.GetType() == typeof(FishPerson))//should check for FishPerson instance EXCLUDING inheritance
            {
                DisplayName.SetDefault("Unknowable");
                return "ArA93&%@MJyt**lf000";
            }
            int nameNum = Main.rand.Next(fishNames.Length);
            return fishNames[nameNum];//uses fishNames from PrismHelper

        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
			button = "D̵̪̜̠͂͊̀́̂̓̎̔̇̈́̀͜į̸͓̭̭̠̖̣͔̭̓̇͑̃̏͗͌̊̎̍͜͝ͅv̵̦̣̖͕̩̩̫̻̣̭̿̀̃̂̀̓̐̄̈i̷̛̳͗͘ď̷͇̻̼͖̅ẹ̷͓͉̳̓̈́͊̑͗͗̂͗ ̷̗̲͙͖̝͋̋̈͆̒̄̊̏̕b̵̨͍̘̫̰̟̟͆̑̑̇̑ỳ̶̹͉̜̠͇͎̟͇͉̘̯̼̒̀̍͐̕̕ ̴̨̭̩̜̮̟̜̻̘͛̋̈́̕͜ż̴̝̝͓̭͕̓͝ͅe̶̮̜̰͇͉͉͓̓̎̔̒̀r̶̡̛̰̰̼̮͕̪̺͔̈́̅̀̄͂̿̏̒o̸̱̍͊̃̆̊̈́͂̂̓͝͝";

		}

        public override void OnChatButtonClicked(bool firstbutton, ref bool shop)
        {
            if(firstbutton)
                int bruh = 1/0;
        }

        public override string GetChat()
        {
            int speakNum = Main.rand.Next(3);
            if (speakNum == 0)
                return "34tijeh iqjpsaiubcn 13iweq @@@@@@@@@@@@@ eruthf912uqwohfd239r0 129704y rqewuhf safndqwopeiuhfn ! ! ! `uh32wqrhsdaxczij";
            else if (speakNum == 1)
                return "oi[qrep @*&#$Yuh12niywgeh837 (@hqp !@)U$h9723hr29q 923h r392 r";
            else if (speakNum == 2)
                return "v fygbuhijo mkojniuhyg8t7298u35 4ed &@#T h0y2uhrd8y09qrw 9302ueds hi238yhgo 0291eidj'";
            else
                return "YOU HAVE REACHED THE UNREACHABLE< ASLDKJHASFKJLHASDFLKJHASDLKJHASFLKJGHASF";
        }
    }
}