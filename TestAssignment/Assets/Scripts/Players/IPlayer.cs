namespace Players
{
    public interface IPlayer
    {
        float Hp { get; }
        float Armor { get; }
        
        void SetHp(float hp);
        void SetArmor(float armor);
    }
}