using UnityEngine.UI;

namespace Ui
{
    public interface IStartButtonsProvider
    {
        Button StartWithBuffsButton { get; }
        Button StartWithoutBuffsButton { get; }
    }
}