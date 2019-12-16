using System;
using System.Collections.Generic;
using GameData;

namespace Players
{
    public class PlayerModel : IPlayerModel
    {
        public event Action<int, EStatType, float> OnChangeStat;
        public event Action<int, List<Buff>> OnChangeBuffs;

        private readonly int _playerId;

        private float _hp;
        private float _armor;
        private float _vampirism;
        private float _damage;

        public float Hp
        {
            get => _hp;
            set
            {
                _hp = GetCheckedValue(value);
                InvokeOnChangeStat(EStatType.Hp, _hp);
            }
        }

        public float Armor
        {
            get => _armor;
            set
            {
                _armor = GetCheckedValue(value);
                InvokeOnChangeStat(EStatType.Armor, _armor);
            }
        }

        public float Vampirism
        {
            get => _vampirism;
            set
            {
                _vampirism = GetCheckedValue(value);
                InvokeOnChangeStat(EStatType.Vampirism, _vampirism);
            }
        }

        public float Damage
        {
            get => _damage;
            set
            {
                _damage = GetCheckedValue(value);
                InvokeOnChangeStat(EStatType.Damage, _damage);
            }
        }

        public PlayerModel(int playerId)
        {
            _playerId = playerId;
        }

        private float GetCheckedValue(float value)
        {
            if (value < 0f)
                return 0f;

            return value;
        }

        public void ApplyDamage(float damage)
        {
            damage *= (1f - 0.01f * Armor);

            if (damage < 0f)
                return;

            if (damage > Hp)
                Hp = 0f;
            else
                Hp -= damage;
        }

        public void ApplyBuffs(List<Buff> buffs)
        {
            foreach (var buff in buffs)
            {
                foreach (var stat in buff.Stats)
                {
                    switch (stat.Type)
                    {
                        case EStatType.Hp:
                            Hp += stat.Value;
                            break;

                        case EStatType.Armor:
                            Armor += stat.Value;
                            break;

                        case EStatType.Damage:
                            Damage += stat.Value;
                            break;

                        case EStatType.Vampirism:
                            Vampirism += stat.Value;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            OnChangeBuffs?.Invoke(_playerId, buffs);
        }

        private void InvokeOnChangeStat(EStatType type, float value)
        {
            OnChangeStat?.Invoke(_playerId, type, value);
        }
    }
}