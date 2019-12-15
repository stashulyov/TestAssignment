namespace Players
{
    public interface IPlayerModel
    {
        float Hp { get; set; }
        float Armor { get; set; }
        float Vampirism { get; set; }
        float Damage { get; set; }

        void Attack(float damage);
    }
}