using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;

namespace prismmod
{
    internal class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Disable Developer items")]
        [Tooltip("Removes developer items from the game. This action requires a mod reload.")]
        [ReloadRequired]
        [DefaultValue(false)]
        public bool DisableDevItems { get; set; }

        [Label("Disable Lore")]
        [Tooltip("Removes lore items from the game. This action requires a mod reload.")]
        [ReloadRequired]
        [DefaultValue(false)]
        public bool DisableLore { get; set; }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            if (Main.player[whoAmI].name == "CommieSlayer")
            {
                return true;
            }
            return false;
        }
    }

    /*class ClientConfig: ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
    }*/
}