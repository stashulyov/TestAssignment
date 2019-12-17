using Core;
using ScriptableObjects;

namespace Ui
{
    public class IconsDatabase : ADatabase<string, Icon>, IIconsDatabase
    {
        public IconsDatabase(IconsDatabaseAsset iconsDatabaseAsset)
        {
            foreach (var icon in iconsDatabaseAsset.List)
                Add(icon.Id, icon);
        }
    }
}