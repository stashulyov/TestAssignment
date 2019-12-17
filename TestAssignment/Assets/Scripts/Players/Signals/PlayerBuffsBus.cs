using System.Collections.Generic;

namespace Players
{
    public class PlayerBuffsBus : IPlayerBuffsBus
    {
        private readonly List<IPlayerBuffsAttachedListener> _attachListeners;
        private readonly List<IPlayerBuffsDetachedListener> _detachListeners;

        public PlayerBuffsBus(List<IPlayerBuffsAttachedListener> attachListeners, List<IPlayerBuffsDetachedListener> detachListeners)
        {
            _attachListeners = attachListeners;
            _detachListeners = detachListeners;
        }

        public void Fire(PlayerBuffsAttachedSignal signal)
        {
            foreach (var listener in _attachListeners)
                listener.OnBuffsAttached(signal);
        }

        public void Fire(PlayerBuffsDetachedSignal signal)
        {
            foreach (var listener in _detachListeners)
                listener.OnBuffsDetached(signal);
        }
    }
}