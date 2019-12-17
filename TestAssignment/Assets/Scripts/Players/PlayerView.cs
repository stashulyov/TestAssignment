using UnityEngine;

namespace Players
{
    public class PlayerView : MonoBehaviour, IPlayerView, IDamageable
    {
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");
        private static readonly int HealthFloat = Animator.StringToHash("Health");

        public int PlayerId { get; private set; }

        private Animator _animator;
        private GameObject _gameObject;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetId(int playerId)
        {
            PlayerId = playerId;
        }

        public int GetEnemyId()
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo))
            {
                var otherPlayerView = hitInfo.transform.GetComponent<IDamageable>();
                return otherPlayerView.PlayerId;
            }

            return -1;
        }

        public void Attack()
        {
            _animator.SetTrigger(AttackTrigger);
        }

        public void Spawn()
        {
            _animator.SetInteger(HealthFloat, 100);
        }

        public void Die()
        {
            _animator.SetInteger(HealthFloat, 0);
        }
    }
}