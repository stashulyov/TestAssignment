namespace Players
{
    public interface IPlayerModel
    {
        float Hp { get; }
        float Armor { get; }
        float Vampirism { get; }
        float Damage { get; }

        void SetHp(float hp);
        void SetArmor(float armor);
        void SetVampirism(float vampirism);
        void SetDamage(float damage);
        
        void Attack(float damage);
    }
}