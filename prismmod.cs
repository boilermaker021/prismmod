using Terraria.ID;
using Terraria.ModLoader;

namespace prismmod
{
    internal class prismmod : Mod
    {
        public static ModHotKey updash;
        public static ModHotKey downdash;

        public prismmod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load()
        {
            updash = RegisterHotKey("Upwards Dash (Double Press)", "W");
            downdash = RegisterHotKey("Downwards Dash (Double Press)", "S");
        }

        public override void Unload()
        {
            updash = null;
            downdash = null;
        }

        public override void AddRecipes()
        {
            ModRecipe ironConverted = new ModRecipe(this);
            ironConverted.AddIngredient(ItemID.CopperBar, 2);
            ironConverted.AddTile(this, "Converter");
            ironConverted.SetResult(ItemID.IronBar);
            ironConverted.AddRecipe();

            ModRecipe tleadConverted = new ModRecipe(this);
            tleadConverted.AddIngredient(ItemID.TinBar, 2);
            tleadConverted.AddTile(this, "Converter");
            tleadConverted.SetResult(ItemID.LeadBar);
            tleadConverted.AddRecipe();

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