using Terraria.UI;
using Terraria.ModLoader;
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
}