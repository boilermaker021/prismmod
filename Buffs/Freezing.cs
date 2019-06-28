using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod.Buffs
{
	public class Freezing : ModBuff
	{

		public override void Update(NPC target, ref int buffIndex)
		{
            target.velocity.Y = 9.8f;
            target.velocity.X = 0f;
		}
	}
}
