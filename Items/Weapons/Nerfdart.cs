using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections;

namespace prismmod.Items.Weapons
{
    public class Nerfdart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nerf Dart");
            Tooltip.SetDefault("A weak Nerf dart that does almost no damage");
        }

        public override void SetDefaults()
        {
            item.damage = 69420;
            item.ranged = true;
            item.width = 6;
            item.height = 2;
            item.maxStack = 999;
            item.consumable = true; //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.value = 10;
            item.rare = 2;
            item.shoot = mod.ProjectileType("Nerf Dart"); //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 12f; //The speed of the projectile
            item.ammo = item.type; //The ammo class this ammo belongs to.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }



        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            position = new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y);
            speedX = 0f;
            speedY = 0f;
            return true;
        }
    }
}