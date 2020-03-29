using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace prismmod.Utils
{
    abstract class PrismPrefab
    {
        int height;
        int width;
        bool faceLeft;
        int[,] structure = {
            { },
            { },
            { }
        };

        public abstract Point drawStructure(int x, int y, char direction);

        public virtual void setDirection(bool faceLeft)
        {
            if (this.faceLeft != faceLeft)
            {
                //flip code here
            }
        }

        public virtual int[,] getArray()
        {
            return this.structure;
        }
    }
}
