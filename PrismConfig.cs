using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace prismmod
{
    class ServerConfig: ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Disable Developer items")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool DisableDevItems {get; set;};

    }

    class ClientConfig: ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

    }

}