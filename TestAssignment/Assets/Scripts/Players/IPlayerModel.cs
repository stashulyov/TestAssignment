namespace Players
{
    public interface IPlayerModel
    {
        float Hp { get; }
        float Armor { get; }
        
        void SetHp(float hp);
        void SetArmor(float armor);
        void Damage(float damage);
    }
}