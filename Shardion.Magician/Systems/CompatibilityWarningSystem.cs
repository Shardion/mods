using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class CompatibilityWarningSystem : ModSystem
    {
        public static List<string> CompatibilityWarnings;

        public override void OnWorldLoad()
        {
            base.OnWorldLoad();
            if (ClientsideLagPrevention.DoCompatibilityWarnings && CompatibilityWarnings.Count > 0)
            {
                foreach (string warning in CompatibilityWarnings)
                {
                    Main.NewText(Language.GetText(warning));
                }
                Main.NewText(Language.GetText("Mods.ClientsideLagPrevention.Common.CompatibilityIssueWarning"));
            }
        }
    }
}