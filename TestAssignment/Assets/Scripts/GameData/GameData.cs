using System;

namespace GameData
{
    [Serializable]
    public class GameData
    {
        public GameModelData settings;
        public StatData[] stats;
        public BuffData[] buffs;
    }

    [Serializable]
    public class GameModelData
    {
        public int buffCountMin;
        public int buffCountMax;
        public bool allowDuplicateBuffs;
    }

    [Serializable]
    public class StatData
    {
        public int id;
        public string title;
        public string icon;
        public float value;
    }

    [Serializable]
    public class BuffStatData
    {
        public float value;
        public int statId;
    }

    [Serializable]
    public class BuffData
    {
        public string icon;
        public int id;
        public string title;
        public BuffStatData[] stats;
    }
}