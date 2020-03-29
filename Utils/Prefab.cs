using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace prismmod.Utils
{
    abstract class PrismPrefab
    {
        protected int height;
        protected int width;
        protected bool faceLeft;
        protected int[,] structure = {
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
