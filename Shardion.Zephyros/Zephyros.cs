using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros
{
    public class Zephyros : Mod
    {
        public static Asset<Texture2D> blackThread;
        public static Asset<Texture2D> greenThread;
        public static Asset<Texture2D> pinkThread;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                blackThread = Assets.Request<Texture2D>("Assets/VV/Items/Crafting/Thread/BlackThread");
                greenThread = Assets.Request<Texture2D>("Assets/VV/Items/Crafting/Thread/GreenThread");
                pinkThread = Assets.Request<Texture2D>("Assets/VV/Items/Crafting/Thread/PinkThread");

                //const string sockPath = $"{nameof(ShardionsMod)}/Assets/VV/Items/Vanity/Sophisticated/";
                // Absolutely awful hardcode that doesn't even work
                // Waiting until custom names for equiptextures are fixed
                /*AddEquipTexture(null, EquipType.Legs, "SophisticatedStockings_FemaleLegs", sockPath + "SophisticatedStockings_FemaleLegs");
                AddEquipTexture(null, EquipType.Legs, "SophisticatedStockingsNoBand_FemaleLegs", sockPath + "SophisticatedStockingsNoBand_FemaleLegs");
                AddEquipTexture(null, EquipType.Legs, "SophisticatedStockingsNoSuspenders_FemaleLegs", sockPath + "SophisticatedStockingsNoSuspenders_FemaleLegs");
                AddEquipTexture(null, EquipType.Legs, "SophisticatedStockingsNoBandNoSuspenders_FemaleLegs", sockPath + "SophisticatedStockings/SophisticatedStockingsNoBandNoSuspenders_FemaleLegs");
                AddEquipTexture(null, EquipType.Legs, "SophisticatedStockingsBlack_FemaleLegs", sockPath + "SophisticatedStockings/SophisticatedStockingsBlack_FemaleLegs");
                AddEquipTexture(null, EquipType.Legs, "SophisticatedStockingsBlackNoSuspenders_FemaleLegs", sockPath + "SophisticatedStockings/SophisticatedStockingsBlackNoSuspenders_FemaleLegs");*/

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
