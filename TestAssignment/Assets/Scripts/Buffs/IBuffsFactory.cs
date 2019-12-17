using System.Collections.Generic;
using GameData;

namespace Buffs
{
    public interface IBuffsFactory
    {
        List<Buff> Create();
    }
}