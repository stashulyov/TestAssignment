using System;
using GameData;

namespace Players
{
    public class PlayerModel : IPlayerModel
    {
        public event Action<EStatType, float> OnChange;

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
                OnChange?.Invoke(EStatType.Hp, _hp);
            }
        }

        public float Armor
        {
            get => _armor;
            set
            {
                _armor = GetCheckedValue(value);
                OnChange?.Invoke(EStatType.Armor, _armor);
            }
        }

        public float Vampirism
        {
            get => _vampirism;
            set
            {
                _vampirism = GetCheckedValue(value);
                OnChange?.Invoke(EStatType.Vampirism, _vampirism);
            }
        }

        public float Damage
        {
            get => _damage;
            set
            {
                _damage = GetCheckedValue(value);
                OnChange?.Invoke(EStatType.Damage, _damage);
            }
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
    }
}