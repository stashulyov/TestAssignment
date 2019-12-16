using System;

namespace Ui.StatUi
{
    public interface IStatUiFactory
    {
        StatUiPresenter Create(Action<StatUiPresenter> despawnCallback);
    }
}