namespace Players
{
    public class PlayerModel : IPlayerModel
    {
        public float Hp { get; private set; }
        public float Armor { get; private set; }

        public void SetHp(float hp)
        {
            Hp = GetCheckedValue(hp);
        }

        public void SetArmor(float armor)
        {
            Armor = GetCheckedValue(armor);
        }

        private float GetCheckedValue(float value)
        {
            if (value < 0f)
                return 0f;

            return value;
        }

        public void Damage(float damage)
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