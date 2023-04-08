using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Shardion.Magician.Systems
{
    public class CompatibilityWarningSystem : ModSystem
    {
        private static readonly List<string> _delayedCompatibilityWarnings = new();
        private static bool _loadedIntoWorld;
        private static bool _sentPostWarning;
        private static bool _fireOnce = true;

        /// <summary>
        /// Adds a compatibility warning.
        /// Added compatibility warnings are printed to chat as soon as possible,
        /// either immediately or upon world join, and logged to the console immediately.
        /// </summary>
        public static void AddCompatibilityWarning(string translationKey, Exception? exception = null)
        {
            if (_loadedIntoWorld)
            {
                Main.NewText(Language.GetTextValue(translationKey), 255, 0, 0);
                if (!_sentPostWarning)
                {
                    Main.NewText(Language.GetTextValue("Mods.ClientsideLagPrevention.Common.CompatibilityIssueWarning"), 255, 0, 0);
                    _sentPostWarning = true;
                }
            }
            else
            {
                _delayedCompatibilityWarnings.Add(translationKey);
            }
            ModLoader.GetMod("ClientsideLagPrevention").Logger.Error(translationKey);
            if (exception != null)
            {
                ModLoader.GetMod("ClientsideLagPrevention").Logger.Error(exception);
            }
        }

        public override void PostUpdateEverything()
        {
            base.PostUpdateEverything();
            if (_fireOnce)
            {
                _loadedIntoWorld = true;
                if (ClientsideLagPrevention.DoCompatibilityWarnings && _delayedCompatibilityWarnings.Count > 0)
                {
                    foreach (string warning in _delayedCompatibilityWarnings)
                    {
                        Main.NewText(Language.GetTextValue(warning), 255, 0, 0);
                    }
                    _delayedCompatibilityWarnings.Clear();
                    if (!_sentPostWarning)
                    {
                        Main.NewText(Language.GetTextValue("Mods.ClientsideLagPrevention.Common.CompatibilityIssueWarning"), 255, 0, 0);
                        _sentPostWarning = true;
                    }
                }
                _fireOnce = false;
            }
        }
    }
}
