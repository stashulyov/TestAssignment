using System.Collections.Generic;

namespace Core
{
    public class UpdatablePublisher : IUpdatablePublisher
    {
        private readonly List<IUpdatable> _updatables;

        public UpdatablePublisher(List<IUpdatable> updatables)
        {
            _updatables = updatables;
        }

        public void Update(float deltaTime)
        {
            foreach (var item in _updatables)
                item.Update(deltaTime);
        }
    }
}