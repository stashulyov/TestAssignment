using UnityEngine.UI;

namespace Players
{
    public interface IAttackButtonProvider
    {
        Button GetAttackButton(int playerId);
    }
}