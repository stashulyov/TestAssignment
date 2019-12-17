using System.Collections.Generic;

namespace Core
{
    public class InitializePublisher : IInitializePublisher
    {
        private readonly List<IInitializable> _initializables;

        public InitializePublisher(List<IInitializable> initializables)
        {
            _initializables = initializables;
        }

        public void Initialize()
        {
            foreach (var item in _initializables)
                item.Initialize();
        }
    }
}