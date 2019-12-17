using Core;
using ScriptableObjects;
using Ui;

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
                var buffUi = new BuffUi(data.title, icon);

                Add(type, buffUi);
            }
        }
    }
}