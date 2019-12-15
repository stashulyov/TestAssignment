using UnityEngine;

namespace Common
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private MonoBehaviourServiceLocator _monoBehaviourServiceLocator;
        
        private void Awake()
        {
            var infrastructure = new Infrastructure(_monoBehaviourServiceLocator);
            infrastructure.BuildGraph();
        }
    }
}