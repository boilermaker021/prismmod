using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace prismmod
{
    class PrismPlayer : ModPlayer
    {
        Random rndm = new Random();
        public float noAmmoUseChance = 0;
        public float IncreaseBulletSpeed = 0;
        public int timesBounced = 0;

        
        public override bool ConsumeAmmo(Item weapon, Item ammo)
        {
            double number = rndm.NextDouble();
            if (number < noAmmoUseChance)
            {
                noAmmoUseChance = 0f;
                return false;
            }
            noAmmoUseChance = 0f;
            return true;
        }

        


    }
}
