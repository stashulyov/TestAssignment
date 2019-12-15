using Core;
using UnityEngine;

namespace Common
{
    public class GameDirector : IGameDirector, IInitializable
    {
        private readonly IPlayerModelBuilder _playerModelBuilder;
        private readonly IUiBuilder _uiBuilder;
        private readonly MonoBehaviourServiceLocator _monoBehaviourServiceLocator;

        public GameDirector(IPlayerModelBuilder playerModelBuilder, IUiBuilder uiBuilder, MonoBehaviourServiceLocator monoBehaviourServiceLocator)
        {
            _playerModelBuilder = playerModelBuilder;
            _uiBuilder = uiBuilder;
            _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
        }

        public void Initialize()
        {
            var ids = new int[]
            {
                0, 1
            };

            var hierarchies = _monoBehaviourServiceLocator.UiObjects.Hierarchies;
            var transforms = new Transform[hierarchies.Length];

            for (int i = 0; i < hierarchies.Length; i++)
                transforms[i] = hierarchies[i].statsPanel;

            _playerModelBuilder.Build(ids);
            _uiBuilder.Build(ids, transforms);
        }
    }
}