using System.Collections.Generic;

namespace Players
{
    public class PlayerAddedBus : IPlayerAddedBus
    {
        private List<IPlayerAddedListener> _listeners;

        public PlayerAddedBus(List<IPlayerAddedListener> listeners)
        {
            _listeners = listeners;
        }

        public void Fire(PlayerAddedSignal signal)
        {
            foreach (var listener in _listeners)
                listener.OnPlayerAdded(signal);
        }
    }
}