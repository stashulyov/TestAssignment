using UnityEngine;

namespace Players
{
    public class PlayerView : IPlayerView
    {
        private Animator _animator;

        public void AddAnimator(Animator animator)
        {
            _animator = animator;
        }
    }
}