using System.Collections.Generic;

namespace Signals
{
    public interface IGameStartedBus
    {
        void Fire(GameStartedSignal signal);
    }

    public class GameStartedBus : IGameStartedBus
    {
        private readonly List<IGameStartedListener> _listeners;

        public GameStartedBus(List<IGameStartedListener> listeners)
        {
            _listeners = listeners;
        }

        public void Fire(GameStartedSignal signal)
        {
            foreach (var listener in _listeners)
                listener.OnGameStarted(signal);
        }
    }
}