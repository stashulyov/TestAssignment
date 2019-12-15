using Common;
using Core;
using ScriptableObjects;

namespace GameData
{
    public class BuffUiDatabase : ADatabase<EBuffType, BuffUi>, IBuffUiDatabase
    {
        public BuffUiDatabase(GameDataProvider gameDataProvider, IIconsDatabase iconsDatabase)
        {
            foreach (var data in gameDataProvider.Data.buffs)
            {
                var type = (EBuffType) data.id;
                var icon = iconsDatabase.Get(data.icon);
                var buffUi = new BuffUi(type, data.title, icon);
                
                Add(type, buffUi);
            }
        }
    }
}