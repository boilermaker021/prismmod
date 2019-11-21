using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using prismmod.NPCs.WaterTown;

namespace prismmod.NPCs.WaterTown
{
    //@todo add head file for these NPCS
    [AutoloadHead]
    internal class FishBlue : FishPerson
    {

        public override string TownNPCName()
        {
            return "Blue Fish";//@todo generate random names for this fishy individual

        }

        public override void SetChatButtons(ref string button, ref string button2) {
			button = "Bruh";
			button2 = "Moment";
		}
        public override string GetChat()
        {
            return "This is the only chat message so far, stop trying for a new one.";
        }
        public override void OnChatButtonClicked(bool firstbutton, ref bool shop)
        {
            shop=true;
        }

        //@todo Setup Shop method



    }
}
