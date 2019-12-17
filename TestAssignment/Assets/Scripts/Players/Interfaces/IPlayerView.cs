namespace Players
{
    public interface IPlayerView
    {
        void SetId(int playerId);
        int GetEnemyId();
        void Attack();
        void Spawn();
        void Die();
    }
}