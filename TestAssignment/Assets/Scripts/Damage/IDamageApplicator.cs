namespace Common
{
    public interface IDamageApplicator
    {
        void ApplyDamage(int attackerId, int attackedId);
    }
}