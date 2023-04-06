using System;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Common.Utilities
{
    /// <summary>
    /// Manages a vanilla buff.
    /// Managed buffs cannot be cancelled or otherwise removed.
    /// </summary>
    public class BuffManager
    {
        public int Type { get; }
        public Player Player { get; }
        public Timer Duration { get; set; } = new();
        public virtual bool HasDuration => true;

        private int ManagedBuffIndex = -1;

        public BuffManager(int type, Timer duration, Player player)
        {
            Type = type;
            Duration = duration;
            Player = player;
        }

        public virtual bool PreUpdate()
        {
            return true;
        }

        public virtual void PostUpdate()
        {

        }

        public void Update()
        {
            if (PreUpdate())
            {
                if ((HasDuration && Duration.Ticks > 0) || !HasDuration)
                {
                    if (ManagedBuffIndex > 0)
                    {
                        if (Player.buffType[ManagedBuffIndex] != Type)
                        {
                            // Buff order changed. Find the buff with the requested type.
                            ManagedBuffIndex = FindBuff(Type);
                            if (ManagedBuffIndex == -1)
                            {
                                // Buff was removed. Make a new one, and find it.
                                Player.AddBuff(Type, Duration.Ticks);
                                ManagedBuffIndex = FindBuff(Type);
                            }
                        }
                        if (HasDuration)
                        {
                            Player.buffTime[ManagedBuffIndex] = Duration.Ticks;
                            Duration.Ticks--;
                        }
                        else
                        {
                            Player.buffTime[ManagedBuffIndex] = int.MaxValue;
                        }
                    }
                    else
                    {
                        Player.AddBuff(Type, Duration.Ticks);
                        ManagedBuffIndex = FindBuff(Type);
                    }
                    PostUpdate();
                }
            }
        }

        /// <summary>Returns the index of the buff of the specified <paramref name="type"/>, or -1 if it is not present.</summary>
        private int FindBuff(int type)
        {
            for (int buffIndex = 0; buffIndex < Player.buffType.GetUpperBound(0) + 1; buffIndex++)
            {
                if (Player.buffType[buffIndex] == type)
                {
                    return buffIndex;
                }
            }
            return -1;
        }

        public string Serialize()
        {
            return OnSerialize($"{Type},{Duration.Ticks}");
        }

        public virtual string OnSerialize(string serializedManagedBuff)
        {
            return serializedManagedBuff;
        }

        public virtual void OnDeserialize(string[] serializedManagedBuffParts)
        {

        }

        public virtual void OnDeserializeException()
        {

        }

        public BuffManager(string serializedManagedBuff, Player player)
        {
            string[] splitSerializedRitual = serializedManagedBuff.Split(',', 3);

            Player = player;

            try
            {
                if (int.TryParse(splitSerializedRitual[0], out int buffType))
                {
                    Type = buffType;
                }
                else
                {
                    Type = 0;
                    Logging.PublicLogger.Error($"Zephyros: Failed deserializing the buff granted by a Buff Manager for player {player}.");
                    Logging.PublicLogger.Error($"Serialized ritual: {serializedManagedBuff}");
                }

                if (int.TryParse(splitSerializedRitual[1], out int durationTicks))
                {
                    Duration = new(durationTicks);
                }
                else
                {
                    Duration = new();
                    Logging.PublicLogger.Error($"Zephyros: Failed deserializing the duration of a Buff Manager for player {player}.");
                    Logging.PublicLogger.Error($"Serialized ritual: {serializedManagedBuff}");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Type = 0;
                Duration = new();
                OnDeserializeException();
                Logging.PublicLogger.Error($"Zephyros: Failed deserializing a Buff Manager for player {player}.");
                Logging.PublicLogger.Error($"Serialized ritual: {serializedManagedBuff}");
                Logging.PublicLogger.Error(e);
            }
        }
    }
}
