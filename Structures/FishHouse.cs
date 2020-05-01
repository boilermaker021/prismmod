using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using prismmod.Utils;
using Microsoft.Xna.Framework;

namespace prismmod.Structures
{
    class FishHouse:PrismPrefab
    {
        protected int height = 1;
        protected int width = 1;
        protected int[,] structure = {
            { },
            { },
            { },
        };

        public FishHouse(bool faceLeft): base(faceLeft)
        {
            
        }

        public override Point drawStructure(int x, int y, bool faceLeft)
        {
            return new Point(x, y);
        }

    }
}
