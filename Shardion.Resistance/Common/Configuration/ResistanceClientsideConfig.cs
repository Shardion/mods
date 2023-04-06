using Newtonsoft.Json;
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

        public override void OnLoaded()
        {
        }
    }
}