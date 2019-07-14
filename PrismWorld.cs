
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


        public override void Initialize()
        {
            killedGargantuanTortoise = false;
        }

    }
}
