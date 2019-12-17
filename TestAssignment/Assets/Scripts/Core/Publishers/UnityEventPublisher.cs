using System;
using DependencyInjection;

namespace Core
{
    public class UnityEventPublisher : IUnityEventPublisher
    {
        private readonly InitializePublisher _initializePublisher;
        private readonly UpdatablePublisher _updatablePublisher;
        private readonly DisposablePublisher _disposablePublisher;

        public UnityEventPublisher(Infrastructure infrastructure)
        {
            var interfaceCollector = new InterfacesCollector(infrastructure);

            _initializePublisher = new InitializePublisher(interfaceCollector.GetListTypes<IInitializable>());
            _disposablePublisher = new DisposablePublisher(interfaceCollector.GetListTypes<IDisposable>());
            _updatablePublisher = new UpdatablePublisher(interfaceCollector.GetListTypes<IUpdatable>());
        }

        public void Initialize()
        {
            _initializePublisher.Initialize();
        }

        public void Dispose()
        {
            _disposablePublisher.Dispose();
        }

        public void Update(float deltaTime)
        {
            _updatablePublisher.Update(deltaTime);
        }
    }
}