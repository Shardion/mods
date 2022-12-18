using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Flashback
{
    public class Flashback : Mod
    {
        public static Asset<Texture2D> blackThread;
        public static Asset<Texture2D> greenThread;
        public static Asset<Texture2D> pinkThread;

        public override void Load()
        {
            base.Load();

            if (!Main.dedServ)
            {
                blackThread = Assets.Request<Texture2D>("Assets/VV/Items/Crafting/Thread/BlackThread");
                greenThread = Assets.Request<Texture2D>("Assets/VV/Items/Crafting/Thread/GreenThread");
                pinkThread = Assets.Request<Texture2D>("Assets/VV/Items/Crafting/Thread/PinkThread");

                TextureAssets.Item[ItemID.BlackThread] = blackThread;
                TextureAssets.Item[ItemID.GreenThread] = greenThread;
                TextureAssets.Item[ItemID.PinkThread] = pinkThread;
            }
        }

        public override void Unload()
        {
            blackThread = null;
            pinkThread = null;
            greenThread = null;

            if (!Main.dedServ)
            {
                TextureAssets.Item[ItemID.BlackThread] = null;
                TextureAssets.Item[ItemID.GreenThread] = null;
                TextureAssets.Item[ItemID.PinkThread] = null;
            }

            base.Unload();
        }
    }
}
