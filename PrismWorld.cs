using prismmod.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace prismmod
{
	public class PrismWorld : ModWorld
	{
        public bool killedGargantuanTortoise;
        public bool downedPrismachine;


        public override void Initialize()
        {
            killedGargantuanTortoise = false;
            downedPrismachine = false;
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = killedGargantuanTortoise;
            flags[1] = downedPrismachine;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            killedGargantuanTortoise = flags[0];
            downedPrismachine = flags[1];
        }

    }
}
