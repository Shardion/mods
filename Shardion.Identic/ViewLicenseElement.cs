using System.Text;
using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.UI.States;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;

namespace Shardion.Identic
{
    public class ViewLicenseElement : ClickableButtonElement
    {
        private UIElement? _textContainer;
        private UIScrollbar? _textContainerScrollbar;
        private UIMessageBox? _text;
        private bool _expanded;
        private bool _justChangedState;
        private string _licenseText = "";
        private StyleDimension _originalHeight;

        public override void ButtonClicked(string parameter)
        {
            if (string.IsNullOrEmpty(_licenseText))
            {
                if (!ModLoader.TryGetMod(parameter, out Mod mod))
                {
                    Logging.PublicLogger.Error($"License viewer element called with nonexistent mod name: {parameter}");
                    return;
                }
                else
                {
                    if (!mod.GetFileNames().Contains("LICENSE"))
                    {
                        Logging.PublicLogger.Error($"Mod {mod} has no LICENSE file");
                        return;
                    }
                    if (Encoding.UTF8.GetString(mod.GetFileBytes("LICENSE")) is not string licenseText)
                    {
                        Logging.PublicLogger.Error($"Mod {mod} has invalid, non-UTF8 license text");
                    }
                    else
                    {
                        _licenseText = licenseText;
                    }
                }
            }
            _expanded = !_expanded;
            _justChangedState = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (_expanded && _justChangedState)
            {
                MinHeight.Set(_originalHeight.Pixels + 405f, 0f);
                _text?.SetText(_licenseText, 0.80f, false);
                Append(_text);
                _justChangedState = false;
            }
            else if (!_expanded && _justChangedState)
            {
                MinHeight.Set(_originalHeight.Pixels, 0f);
                _text?.Remove();
                _text?.SetText("");
                _justChangedState = false;
            }
            base.Update(gameTime);
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            _originalHeight = Height;

            _text = new("");
            _text.Width = StyleDimension.Fill;
            _text.Height.Set(400f, 0);
            _text.Top.Set(Height.Pixels, 0f);

            _textContainerScrollbar = new();
            _textContainerScrollbar.WithView(100f, 1000f);
            _textContainerScrollbar.HAlign = 1.0f;
            _textContainerScrollbar.Height = StyleDimension.Fill;

            _text.SetScrollbar(_textContainerScrollbar);
            _text.Append(_textContainerScrollbar);
            Append(_text);

            MaxHeight.Set(Height.Pixels + 430f, 0f);
            _justChangedState = true;
        }

        public override void ScrollWheel(UIScrollWheelEvent evt)
        {
            if (_textContainerScrollbar != null)
            {
                float oldpos = _textContainerScrollbar.ViewPosition;

                _textContainerScrollbar.ViewPosition -= evt.ScrollWheelValue;

                if (oldpos == _textContainerScrollbar.ViewPosition)
                {
                    base.ScrollWheel(evt);
                }
            }
            else
            {
                base.ScrollWheel(evt);
            }
        }

        public override void Recalculate()
        {
            base.Recalculate();

            if (_text != null)
            {
                float defaultHeight = 30;
                float h = _text.Parent != null ? _text.Height.Pixels + defaultHeight : defaultHeight; // 24 for UIElement

                MaxHeight.Set(400, 0f);
                Height.Set(h, 0f);

                if (Parent != null && Parent is UISortableElement)
                {
                    Parent.Height.Set(h, 0f);
                }
            }
        }
    }
}
