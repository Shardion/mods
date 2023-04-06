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

        /// <summary>
        /// Adds a compatibility warning.
        /// Added compatibility warnings are printed to chat as soon as possible,
        /// either immediately or upon world join, and logged to the console immediately.
        /// </summary>
        public static void AddCompatibilityWarning(string translationKey, Exception? exception = null)
        {
            if (_loadedIntoWorld)
            {
                Main.NewText(Language.GetText(translationKey));
                if (!_sentPostWarning)
                {
                    Main.NewText(Language.GetText("Mods.ClientsideLagPrevention.Common.CompatibilityIssueWarning"));
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

        public override void OnWorldLoad()
        {
            base.OnWorldLoad();
            _loadedIntoWorld = true;
            if (ClientsideLagPrevention.DoCompatibilityWarnings && _delayedCompatibilityWarnings.Count > 0)
            {
                foreach (string warning in _delayedCompatibilityWarnings)
                {
                    Main.NewText(Language.GetText(warning));
                    _ = _delayedCompatibilityWarnings.Remove(warning);
                }
                if (!_sentPostWarning)
                {
                    Main.NewText(Language.GetText("Mods.ClientsideLagPrevention.Common.CompatibilityIssueWarning"));
                    _sentPostWarning = true;
                }
            }
        }

    }
}
