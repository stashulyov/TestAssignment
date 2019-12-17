using Core;
using UnityEngine;

namespace DependencyInjection
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private MonoBehaviourServiceLocator _monoBehaviourServiceLocator;
        
        private UnityEventPublisher _unityEventPublisher;

        private void Awake()
        {
            var infrastructure = new Infrastructure(_monoBehaviourServiceLocator);
            infrastructure.BuildGraph();

            _unityEventPublisher = new UnityEventPublisher(infrastructure);
        }

        private void Start()
        {
            _unityEventPublisher.Initialize();
        }

        private void Update()
        {
            _unityEventPublisher.Update(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _unityEventPublisher.Dispose();
        }
    }
}