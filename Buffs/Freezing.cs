using Terraria;
using Terraria.ModLoader;

namespace prismmod.Buffs
{
    public class Freezing : ModBuff
    {
        public override void Update(NPC target, ref int buffIndex)
        {
            if (!target.boss)
            {
                target.velocity.X = 0f;
                target.velocity.Y = 0f;
            }
            else
            {
                target.velocity *= 0.95f;
            }
        }
    }
}