using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ManagedDoom.Audio;
using ManagedDoom.UserInput;
using ManagedDoom;

namespace Shardion.Limbo.Doom
{
    public class TerrariaDoom : IDisposable
    {
        private Config config;
        private DoomTexture2DVideo video;
        private NullSound sound;
        private NullMusic music;
        private NullUserInput userInput;
        private ManagedDoom.Doom doom;
        private GameContent content;

        public TerrariaDoom()
        {
            config = new Config();
            config.video_screenwidth = 320;
            config.video_screenheight = 200;

            content = new GameContent(new CommandLineArgs(new string[] { "-iwad", "/tmp/DOOM.WAD" }));
            video = new(config, content);
            sound = new();
            music = new();
            userInput = new();

            doom = new ManagedDoom.Doom(new CommandLineArgs(new string[] { "-iwad", "/tmp/DOOM.WAD" } ), config, content, video, sound, music, userInput);
        }

        public Texture2D GetDoomTexture()
        {
            return video.Texture;
        }

        public void Update()
        {
            doom.Update();
        }

        public void Draw()
        {
            video.Render(doom);
        }

        public void Dispose()
        {
            if (video != null)
            {
                video.Dispose();
            }

            if (content != null)
            {
                content.Dispose();
            }
        }
    }
}
