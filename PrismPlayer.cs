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
        public float flamerDamageIncrease = 1f;
        public float flamerSpeedIncrease = 1f;
        public float rocketDamageIncrease = 1f;
        public float bulletDamageIncrease = 1f;
        public float arrowDamageIncrease = 1f;
        public float arrowsFreezeEnemies = 0f;
        public float twoShotRocket = 0f;


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
        public override void ResetEffects()
        {
            flamerDamageIncrease = 1f;
            flamerSpeedIncrease = 1f;
            rocketDamageIncrease = 1f;
            bulletDamageIncrease = 1f;
            arrowDamageIncrease = 1f;
            arrowsFreezeEnemies = 0f;
            twoShotRocket = 0f;
        }

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (item.useAmmo == AmmoID.Gel)
            {
                damage = (int)((float)damage * flamerDamageIncrease);
                speedY *= flamerSpeedIncrease;
                speedX *= flamerSpeedIncrease;

            }
            if (item.useAmmo == AmmoID.Rocket)
            {
                damage = (int)((float)damage * rocketDamageIncrease);
				double number = rndm.NextDouble();
				if(number < twoShotRocket)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY);
					perturbedSpeed = perturbedSpeed*0.5f;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
            }
            if (item.useAmmo == AmmoID.Bullet)
            {
                damage = (int)((float)damage * bulletDamageIncrease);
            }
            if (item.useAmmo == AmmoID.Arrow)
            {
                damage = (int)((float)damage * arrowDamageIncrease);
            }
            return true;
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (proj.aiStyle == 1)
            {
                double number = rndm.NextDouble();
                if (number < arrowsFreezeEnemies)
                {
                    target.AddBuff(mod.BuffType("Freezing"), 180);//for 3 seconds, can be changed for balancing later
                }
            }
        }
    }
}
