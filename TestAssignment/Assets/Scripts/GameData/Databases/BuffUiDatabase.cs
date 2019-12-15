using Common;
using ScriptableObjects;

namespace GameData
{
    public class BuffUiDatabase : ADatabase<EBuffType, BuffUi>, IBuffUiDatabase
    {
        public BuffUiDatabase(BuffData[] buffData, IIconsDatabase iconsDatabase)
        {
            foreach (var data in buffData)
            {
                var type = (EBuffType) data.id;
                var icon = iconsDatabase.Get(data.icon);
                var buffUi = new BuffUi(type, data.title, icon);
                
                Add(type, buffUi);
            }
        }
    }
}