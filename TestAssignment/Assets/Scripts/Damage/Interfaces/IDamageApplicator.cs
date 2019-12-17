namespace Damage
{
    public interface IDamageApplicator
    {
        bool ApplyDamage(int attackerId, int attackedId);
    }
}