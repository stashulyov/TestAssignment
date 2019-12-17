namespace Players
{
    public interface IPlayerModel
    {
        int PlayerId { get; }

        float Hp { get; set; }
        float Armor { get; set; }
        float Vampirism { get; set; }
        float Damage { get; set; }

        void ApplyDamage(float damage);
    }
}