namespace Players
{
    public class PlayerModel : IPlayerModel
    {
        private float _hp;
        private float _armor;
        private float _vampirism;
        private float _damage;

        public float Hp
        {
            get => _hp;
            set => _hp = GetCheckedValue(value);
        }

        public float Armor
        {
            get => _armor;
            set => _armor = GetCheckedValue(value);
        }

        public float Vampirism
        {
            get => _vampirism;
            set => _vampirism = GetCheckedValue(value);
        }

        public float Damage
        {
            get => _damage;
            set => _damage = GetCheckedValue(value);
        }

        private float GetCheckedValue(float value)
        {
            if (value < 0f)
                return 0f;

            return value;
        }

        public void Attack(float damage)
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