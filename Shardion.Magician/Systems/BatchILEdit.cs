using Terraria.ModLoader;
using MonoMod.Cil;

namespace Shardion.Magician.Systems
{
    public class BatchILEdit : ModSystem
    {
        public virtual ILContext.Manipulator? MethodToEdit => null;
        public virtual LocalizedText? FailiureText => null;
    }
}