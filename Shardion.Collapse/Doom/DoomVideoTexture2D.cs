using System;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using ManagedDoom.Video;
using ManagedDoom;

namespace Shardion.Collapse.Doom
{
    public class DoomTexture2DVideo : IVideo, IDisposable
    {
        private Renderer renderer;

//        private RenderWindow window;

        private int windowWidth;
        private int windowHeight;

        private int textureWidth;
        private int textureHeight;

        private byte[] textureData;
        public Texture2D? Texture { get; set; }
//        private global::SFML.Graphics.Texture texture;
//        private global::SFML.Graphics.Sprite sprite;
//        private global::SFML.Graphics.RenderStates renderStates;

        public DoomTexture2DVideo(Config config, GameContent content)
        {
            try
            {
                Console.Write("Initialize video: ");

                renderer = new Renderer(config, content);

                config.video_gamescreensize = Math.Clamp(config.video_gamescreensize, 0, MaxWindowSize);
                config.video_gammacorrection = Math.Clamp(config.video_gammacorrection, 0, MaxGammaCorrectionLevel);

                windowWidth = 128;
                windowHeight = 128;
                textureWidth = 128;
                textureHeight = 128;

                textureData = new byte[4 * renderer.Width * renderer.Height];
                Texture = new Texture2D(Main.graphics.GraphicsDevice, textureWidth, textureHeight);

                Console.WriteLine("OK");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed");
                Dispose();
            }
        }

        public void Render(ManagedDoom.Doom doom)
        {
            renderer.Render(doom, textureData);
            Texture?.SetData(textureData);
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
            Console.WriteLine("Shutdown renderer.");

            if (Texture != null)
            {
                Texture.Dispose();
                Texture = null;
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
