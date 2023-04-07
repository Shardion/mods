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
    }
}