using System;
using System.Reflection;
using System.Collections.Generic;
using Terraria.ModLoader;
using Shardion.Flashback.Internal;

namespace Shardion.Flashback
{
    public partial class Flashback : Mod
    {
        private int[] equipTextures = Array.Empty<int>();
    
        private void AutoloadFemaleLegsTextures()
        {
/*            foreach (VanityItem item in ConstructObjects<VanityItem>(FindSubclasses<VanityItem>()))
            {
                if (item.FemaleLegTexture != null)
                {
                    if (ModContent.HasAsset(item.FemaleLegTexture))
                    {
                        string[] splitTextureName = item.FemaleLegTexture.Split("/");
                        string textureName = splitTextureName[splitTextureName.GetUpperBound(0)];
                        equipTextures[item.Type] = EquipLoader.AddEquipTexture(this, textureName, EquipType.Legs, null, textureName);
                    }
                }
            }*/
        }

        private void UnloadFemaleLegsTextures()
        {
            // TODO: Do we need to unload equip textures?
        }

        private List<T> ConstructObjects<T>(List<Type> types) where T : class
        {
            List<T> constructedTypes = new();
            foreach (Type type in types)
            {
                ConstructorInfo? arglessConstructor = type.GetConstructor(Array.Empty<Type>());
                if (arglessConstructor != null)
                {
                    object constructedObject = arglessConstructor.Invoke(null);
                    if (constructedObject is T constructedType)
                    {
                        constructedTypes.Add(constructedType);
                    }
                }
            }
            return constructedTypes;
        }

        private List<Type> FindSubclasses<T>() where T : class
        {
            List<Type> subclasses = new();
            Assembly assembly = GetType().Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(T)) && !type.IsAbstract && !type.IsInterface && type.IsPublic)
                {
                    subclasses.Add(type);
                }
            }
            return subclasses;
        }
    }
}