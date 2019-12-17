using System.Collections.Generic;

namespace Players
{
    public class PlayerStatChangedBus : IPlayerStatChangedBus
    {
        private readonly List<IPlayerStatChangedListener> _listeners;

        public PlayerStatChangedBus(List<IPlayerStatChangedListener> listeners)
        {
            _listeners = listeners;
        }

        public void Fire(PlayerStatChangedSignal signal)
        {
            foreach (var listener in _listeners)
                listener.OnPlayerStatChanged(signal);
        }
    }
}