using System;

namespace Ui
{
    public interface IStatUiFactory
    {
        StatUiPresenter Create(Action<StatUiPresenter> despawnCallback);
    }
}