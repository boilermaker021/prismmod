using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Buffs
{
	public class NoBounce : ModBuff
	{
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bounced Out!");
            Description.SetDefault("You're Bounced Out! Relax!");
        }

    }
}
