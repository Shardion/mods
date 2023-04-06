using System;
using System.IO;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.ModLoader.Config.UI;

namespace Shardion.Identic
{
    public class ClickableButtonElement : ConfigElement
    {
        public virtual void ButtonClicked(string parameter)
        {

        }

        public override void LeftClick(UIMouseEvent evt)
        {
            base.LeftClick(evt);
            if (GetObject() is string value)
            {
                ButtonClicked(value);
            }
            else
            {
                Logging.PublicLogger.Error($"Clickable button element called with non-string value: {GetObject()}");
            }
        }
    }

    public class ViewLicenseElement : ClickableButtonElement
    {
        public override void ButtonClicked(string parameter)
        {
            if (!ModLoader.TryGetMod(parameter, out Mod mod))
            {
                Logging.PublicLogger.Error($"License viewer element called with nonexistent mod name: {parameter}");
                return;
            }
            else
            {
                if (!mod.HasAsset("LICENSE"))
                {
                    Logging.PublicLogger.Error($"Mod {mod} has no LICENSE file");
                    return;
                }
                if (mod.GetFileBytes("LICENSE").ToString() is not string licenseText)
                {
                    Logging.PublicLogger.Error($"Mod {mod} has invalid, non-UTF8 license text");
                }
                else
                {
                    mod.Logger.Info(licenseText);
                }
            }
        }
    }

    public class ViewSourceElement : ClickableButtonElement
    {
        public override void ButtonClicked(string parameter)
        {
            OpenURI(parameter);
        }

        private static void OpenURI(string uri)
        {
            
        }
    }

    public interface IHasSourceCodeAvailable
    {
        public string SourceCodeURI { get; }
        // Popping calcs on unexpecting modders since 2023
    }
}
