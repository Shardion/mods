using Newtonsoft.Json;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader.Config;
using Shardion.Identic;

namespace Shardion.Summoning.Common.Configuration
{
    public class SummoningConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("$Mods.Summoning.Config.InfoHeader")]
        [JsonIgnore]
        [Label("$Mods.Summoning.Config.ViewLicense.Label")]
        [Tooltip("$Mods.Summoning.Config.ViewLicense.Tooltip")]
        [CustomModConfigItem(typeof(ViewLicenseElement))]
        // Contents are generated from the provided mod's LICENSE file
        public string ViewLicense => "Summoning";

        [JsonIgnore]
        [Label("$Mods.Summoning.Config.ViewSource.Label")]
        [Tooltip("$Mods.Summoning.Config.ViewSource.Tooltip")]
        [CustomModConfigItem(typeof(ViewSourceElement))]
        // Opens the provided URI
        public string ViewSource => "https://github.com/shardion/mods/tree/1.4.4/Shardion.Summoning/";
    }
}
