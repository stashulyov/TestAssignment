using System.Collections.Generic;

namespace Signals
{
    public class UiModelBuiltBus : IUiModelBuiltBus
    {
        private List<IUiModelBuiltListener> _listeners;

        public UiModelBuiltBus(List<IUiModelBuiltListener> listeners)
        {
            _listeners = listeners;
        }

        public void Fire(UiModelBuiltSignal signal)
        {
            foreach (var listener in _listeners)
                listener.OnUiModelBuilt(signal);
        }
    }
}