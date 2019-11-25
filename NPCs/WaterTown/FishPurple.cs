using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using prismmod.NPCs.WaterTown;
using static prismmod.PrismHelper;

namespace prismmod.NPCs.WaterTown
{
    //@todo add head file for these NPCS
    [AutoloadHead]
    internal class FishPurple : FishPerson
    {
        public override string GetChat()
        {
            return "This is the only chat message so far, stop trying for a new one.";
            //request chat messages from braden
        }
        public override void OnChatButtonClicked(bool firstbutton, ref bool shop)
        {
            if(firstbutton)
                shop=true;
            //else do something for second button if we have one...
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //different shop for different fish?
        }



    }
}
