using GameData;

namespace Buffs
{
    public interface IBuffUiDatabase
    {
        BuffUi Get(EBuffType type);
    }
}