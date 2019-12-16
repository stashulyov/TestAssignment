using UnityEngine;

namespace Players
{
    public class PlayerView : MonoBehaviour, IPlayerView, IDamageable
    {
        [SerializeField] private int _id;

        public int Id => _id;

        private Animator _animator;
        private GameObject _gameObject;

        public void AddAnimator(Animator animator)
        {
            _animator = animator;
        }

        public int GetEnemyId()
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo))
            {
                var otherPlayerView = hitInfo.transform.GetComponent<IDamageable>();
                return otherPlayerView.Id;
            }

            return -1;
        }
    }
}