using Newtonsoft.Json;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader.Config;
using Shardion.Identic;

namespace Shardion.Resistance.Common.Configuration
{
    public class HorizonClientsideConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [JsonIgnore]
        [Label("$Mods.Horizon.Config.ViewLicense")]
        [CustomModConfigItem(typeof(ViewLicenseElement))]
        public string ViewLicense => "Horizon";

        [JsonIgnore]
        [Label("$Mods.Horizon.Config.ViewSource")]
        [CustomModConfigItem(typeof(ViewSourceElement))]
        public string ViewSource => "https://github.com/shardion/mods/tree/1.4.4/Shardion.Resistance/";
    }
}
