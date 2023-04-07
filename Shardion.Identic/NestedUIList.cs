// Copied from tModLoader, with modifications, as we can't use it directly, because it's internal
// https://github.com/tModLoader/tModLoader/blob/65f3825badfed4773808e015b8ba32dae58e8b53/patches/tModLoader/Terraria/ModLoader/Config/UI/ListElement.cs

using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.UI;

namespace Shardion.Identic
{
    internal class NestedUIList : UIList
    {
        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);

            PlayerInput.LockVanillaMouseScroll("ModLoader/ListElement");
        }

        public override void ScrollWheel(UIScrollWheelEvent evt)
        {
            if (_scrollbar != null)
            {
                float oldpos = _scrollbar.ViewPosition;

                _scrollbar.ViewPosition -= evt.ScrollWheelValue;

                if (oldpos == _scrollbar.ViewPosition)
                {
                    base.ScrollWheel(evt);
                }
            }
            else
            {
                base.ScrollWheel(evt);
            }
        }
    }
}