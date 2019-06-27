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
            ironConverted.AddIngredient(ItemID.CopperBar, 10);
            ironConverted.AddTile(this, "Converter");
            ironConverted.SetResult(ItemID.IronBar, 3);
            ironConverted.AddRecipe();
            ModRecipe leadConverted = new ModRecipe(this);
            leadConverted.AddIngredient(ItemID.IronBar);
            leadConverted.AddTile(this, "Converter");
            leadConverted.SetResult(ItemID.LeadBar);
            leadConverted.AddRecipe();
            ModRecipe IronlConverted = new ModRecipe(this);
            IronlConverted.AddIngredient(ItemID.LeadBar);
            IronlConverted.AddTile(this, "Converter");
            IronlConverted.SetResult(ItemID.IronBar);
            IronlConverted.AddRecipe();
        }
    }
}
