using System;
using Ui;

namespace Stats
{
    public interface IStatUiFactory
    {
        StatUiPresenter Create(Action<StatUiPresenter> despawnCallback);
    }
}