using Terraria;
using Terraria.ModLoader;

namespace prismmod.Backgrounds
{
	public class ExampleUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.LocalPlayer.GetModPlayer<PrismPlayer>().ZoneWaterTown;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/WaterTownUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/WaterTownUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/WaterTownUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/WaterTownUG3");
		}
	}
}
