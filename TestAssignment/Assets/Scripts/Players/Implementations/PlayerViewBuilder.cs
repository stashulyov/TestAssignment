using Players;
using UnityEngine;

namespace Common
{
    public class PlayerViewBuilder : IPlayerViewBuilder
    {
        private readonly IPlayerViewDatabase _playerViewDatabase;

        public PlayerViewBuilder(IPlayerViewFactory playerViewFactory, IPlayerViewDatabase playerViewDatabase)
        {
            _playerViewDatabase = playerViewDatabase;
        }

        public void Build(int[] playerIds, Animator[] animators)
        {
            for (int i = 0; i < playerIds.Length; i++)
            {
                var id = playerIds[i];
                var animator = animators[i];

                var playerView = animator.GetComponent<PlayerView>();
                playerView.AddAnimator(animator);

                _playerViewDatabase.Add(id, playerView);
            }
        }
    }
}