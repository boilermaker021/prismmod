using Terraria.ModLoader;

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
	}
}
