using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ManagedDoom.Video;
using ManagedDoom;

namespace Shardion.Collapse.Doom
{
    public class DoomTexture2DVideo : IVideo, IDisposable
    {
        private Renderer renderer;

        private byte[] textureData;
        public Texture2D Texture { get { _texture.SetData(0, null, textureData, 0, 1024000); return _texture; } }
        private Texture2D _texture;

        public DoomTexture2DVideo(Config config, GameContent content)
        {
            try
            {
                Shardion.Collapse.Instance.Logger.Debug("Initialize video: ");

                renderer = new Renderer(config, content);

                config.video_gamescreensize = Math.Clamp(config.video_gamescreensize, 0, MaxWindowSize);
                config.video_gammacorrection = Math.Clamp(config.video_gammacorrection, 0, MaxGammaCorrectionLevel);

                textureData = new byte[4 * renderer.Width * renderer.Height];
                _texture = new Texture2D(Main.graphics.GraphicsDevice, renderer.Height, renderer.Width); // doom renders vertically????
                DrawRect = new(0, 0, textureHeight, textureWidth);

                Shardion.Collapse.Instance.Logger.Debug("OK");
            }
            catch (Exception e)
            {
                Shardion.Collapse.Instance.Logger.Debug("Failed");
                Shardion.Collapse.Instance.Logger.Debug(e.Message);
                Dispose();
            }
        }

        public void Render(ManagedDoom.Doom doom)
        {
            renderer.Render(doom, textureData);
        }

        public void InitializeWipe()
        {
            renderer.InitializeWipe();
        }

        public bool HasFocus()
        {
            return true;
        }

        public void Dispose()
        {
            Shardion.Collapse.Instance.Logger.Debug("Shutdown renderer.");

            if (_texture != null)
            {
                _texture.Dispose();
                _texture = null;
            }
        }

        public int WipeBandCount => renderer.WipeBandCount;
        public int WipeHeight => renderer.WipeHeight;

        public int MaxWindowSize => renderer.MaxWindowSize;

        public int WindowSize
        {
            get => renderer.WindowSize;
            set => renderer.WindowSize = value;
        }

        public bool DisplayMessage
        {
            get => renderer.DisplayMessage;
            set => renderer.DisplayMessage = value;
        }

        public int MaxGammaCorrectionLevel => renderer.MaxGammaCorrectionLevel;

        public int GammaCorrectionLevel
        {
            get => renderer.GammaCorrectionLevel;
            set => renderer.GammaCorrectionLevel = value;
        }
    }
}
