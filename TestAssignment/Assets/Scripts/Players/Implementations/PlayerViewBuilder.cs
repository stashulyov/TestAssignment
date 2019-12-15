using Players;
using UnityEngine;

namespace Common
{
    public class PlayerViewBuilder : IPlayerViewBuilder
    {
        private readonly IPlayerViewFactory _playerViewFactory;
        private readonly IPlayerViewDatabase _playerViewDatabase;

        public PlayerViewBuilder(IPlayerViewFactory playerViewFactory, IPlayerViewDatabase playerViewDatabase)
        {
            _playerViewFactory = playerViewFactory;
            _playerViewDatabase = playerViewDatabase;
        }

        public void Build(int[] playerIds, Animator[] animators)
        {
            for (int i = 0; i < playerIds.Length; i++)
            {
                var id = playerIds[i];
                var animator = animators[i];

                var playerView = _playerViewFactory.Create(id);
                playerView.AddAnimator(animator);

                _playerViewDatabase.Add(id, playerView);
            }
        }
    }
}