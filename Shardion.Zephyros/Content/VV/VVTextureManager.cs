using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.VV
{
    public class VVTextureManager : ModSystem
    {
        public static Asset<Texture2D> blackThread;
        public static Asset<Texture2D> greenThread;
        public static Asset<Texture2D> pinkThread;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                blackThread = Mod.Assets.Request<Texture2D>("Assets/VV/Items/Crafting/Thread/BlackThread");
                greenThread = Mod.Assets.Request<Texture2D>("Assets/VV/Items/Crafting/Thread/GreenThread");
                pinkThread = Mod.Assets.Request<Texture2D>("Assets/VV/Items/Crafting/Thread/PinkThread");

                // Absolutely awful hardcode
                // Replace with patented automanualloading:tm:
                _ = EquipLoader.AddEquipTexture(Mod, "ShardionsManyModifications/Assets/VV/Items/Vanity/Sophisticated/SophisticatedStockings_FemaleLegs", EquipType.Legs, null, "SophisticatedStockings_FemaleLegs");
                /*AddEquipTexture(null, EquipType.Legs, "SophisticatedStockingsNoBand_FemaleLegs", sockPath + "SophisticatedStockingsNoBand_FemaleLegs");
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
