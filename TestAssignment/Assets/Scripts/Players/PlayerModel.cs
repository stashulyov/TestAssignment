namespace Players
{
    public class PlayerModel : IPlayerModel
    {
        public float Hp { get; private set; }
        public float Armor { get; private set; }
        public float Vampirism { get; private set; }
        public float Damage { get; private set; }

        public void SetHp(float hp)
        {
            Hp = GetCheckedValue(hp);
        }

        public void SetArmor(float armor)
        {
            Armor = GetCheckedValue(armor);
        }

        public void SetVampirism(float vampirism)
        {
            Vampirism = GetCheckedValue(vampirism);
        }

        public void SetDamage(float damage)
        {
            Damage = GetCheckedValue(damage);
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