using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace prismmod
{
    internal class prismmod : Mod
    {
        //public static ModHotKey updash;

        public prismmod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }


        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
            {
                return;
            }

            if (Main.LocalPlayer.GetModPlayer<PrismPlayer>().ZoneWaterTown)
            {
                Mod musicmod = ModLoader.GetMod("prismmodmusic");
                if (musicmod != null)
                {
                    priority = MusicPriority.BossHigh;
                    music = musicmod.GetSoundSlot(SoundType.Music, "Sounds/Music/Biomes/WaterTown");
                }
            }
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