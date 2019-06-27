using Terraria.ModLoader;
using Terraria.ID;

namespace prismmod
{
	class prismmod : Mod
	{
		public prismmod()
		{

            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };

		}

        public override void AddRecipes()
        {
            ModRecipe ironConverted = new ModRecipe(this);
            ironConverted.AddIngredient(ItemID.CopperBar, 20);
            ironConverted.AddTile(this, "Converter");
            ironConverted.SetResult(ItemID.IronBar);
            ironConverted.AddRecipe();
        }
    }
}
