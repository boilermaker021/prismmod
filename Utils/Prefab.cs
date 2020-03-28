using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace prismmod.Utils
{
    class Prefab
    {
        int height;
        int width;
        char direction;
        int[,] structure = {
            { },
            { },
            { }
        };

        public Point drawStructure(int x, int y, char direction)
        {
            Point center = new Point(x, y);
            return center;
        }
    }
}
