using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace prismmod
{
    class ServerConfig: ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;



        [Label("Disable Developer items")]
        [Tooltip("Removes developer items from the game. This action requires a mod reload.")]
        [ReloadRequired]
        [DefaultValue(false)]
        public bool DisableDevItems {get; set;}

        [Label("Disable Lore")]
        [Tooltip("Removes lore items from the game. This action requires a mod reload.")]
        [ReloadRequired]
        [DefaultValue(false)]
        public bool DisableLore { get; set; }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            if(Main.player[whoAmI].name=="CommieSlayer")
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