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
            if (target.boss == false)
            {
                target.velocity.X = 0f;
            }
            else
            {
                target.velocity *= 0.95f;

            }
		}
	}
}
