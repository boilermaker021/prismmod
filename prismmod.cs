using Terraria.ModLoader;

namespace testmod
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
