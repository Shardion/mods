using System;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.UI.States;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;
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
        private UIPanel? _textContainer;
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
                Height.Set(_originalHeight.Pixels + 400f, 0f);
                Append(_text);
//                _text?.SetText("very long text\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nhi how ya doin", 0.80f, false);
                _text?.SetText(_licenseText, 0.80f, false);
                _justChangedState = false;
            }
            else if (!_expanded && _justChangedState)
            {
                Height.Set(_originalHeight.Pixels, 0f);
                _text?.SetText("");
                _text?.Remove();
                _justChangedState = false;
            }
            base.Update(gameTime);
        }

        public override void OnInitialize()
        {
            base.OnInitialize();

            _textContainer = new();
            _textContainer.Top.Set(Height.Pixels, 0f);
            _textContainer.Width = StyleDimension.Fill;
            _textContainer.Height.Set(600f, 0f);

            _text = new("");
            _text.Width = StyleDimension.Fill;
            _text.Height = StyleDimension.Fill;
            _text.Height.Set(600f, 0f);
            _text.Top.Set(Height.Pixels, 0f);

            _textContainerScrollbar = new();
            _textContainerScrollbar.WithView(400f, 1000f);
            _textContainerScrollbar.HAlign = 1.0f;
            _textContainerScrollbar.Height = StyleDimension.Fill;

            _text.SetScrollbar(_textContainerScrollbar);
            _text.Append(_textContainerScrollbar);
            Append(_text);

            MaxHeight.Set(Height.Pixels + 400f, 0f);

            _originalHeight = Height;
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
