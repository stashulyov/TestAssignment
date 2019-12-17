using System.Collections.Generic;

namespace Ui
{
    public class StatUiPool : IStatUiPool
    {
        private readonly IStatUiFactory _statUiFactory;
        private readonly Stack<StatUiPresenter> _stack;

        public StatUiPool(IStatUiFactory statUiFactory)
        {
            _statUiFactory = statUiFactory;

            _stack = new Stack<StatUiPresenter>();
        }

        public StatUiPresenter Spawn()
        {
            var statUi = GetInternal();

            statUi.SetActive(true);
            return statUi;
        }

        private StatUiPresenter GetInternal()
        {
            if (_stack.Count > 0)
                return _stack.Pop();

            return _statUiFactory.Create(Despawn);
        }

        public void Despawn(StatUiPresenter statUi)
        {
            statUi.SetActive(false);
            _stack.Push(statUi);
        }
    }
}