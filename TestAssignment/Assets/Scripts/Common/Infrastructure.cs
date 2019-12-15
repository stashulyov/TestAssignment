namespace Common
{
    public class Infrastructure
    {
        private readonly MonoBehaviourServiceLocator _monoBehaviourServiceLocator;

        public Infrastructure(MonoBehaviourServiceLocator monoBehaviourServiceLocator)
        {
            _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
        }

        public void BuildGraph()
        {
        }
    }
}