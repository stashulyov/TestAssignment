using System;
using GameData;

namespace Players
{
    public interface IPlayerModel
    {
        event Action<int, EStatType, float> OnChangeStat;
        event Action<int, EBuffType> OnChangeBuff;
        
        float Hp { get; set; }
        float Armor { get; set; }
        float Vampirism { get; set; }
        float Damage { get; set; }

        void ApplyDamage(float damage);
        void ApplyBuff(Buff buff);
    }
}