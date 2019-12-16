using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class GameDirector : IGameDirector, IInitializable
    {
        private readonly IPlayerModelBuilder _playerModelBuilder;
        private readonly IPlayerViewBuilder _playerViewBuilder;
        private readonly IUiBuilder _uiBuilder;
        private readonly MonoBehaviourServiceLocator _monoBehaviourServiceLocator;
        private readonly IAttackUiSystem _attackUiSystem;

        public GameDirector(IPlayerModelBuilder playerModelBuilder, IPlayerViewBuilder playerViewBuilder, IUiBuilder uiBuilder,
            MonoBehaviourServiceLocator monoBehaviourServiceLocator, IAttackUiSystem attackUiSystem)
        {
            _playerModelBuilder = playerModelBuilder;
            _playerViewBuilder = playerViewBuilder;
            _uiBuilder = uiBuilder;
            _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
            _attackUiSystem = attackUiSystem;
        }

        public void Initialize()
        {
            _monoBehaviourServiceLocator.UiObjects.PlayWithBuffsButton.onClick.AddListener(PlayWithBuffs);
            _monoBehaviourServiceLocator.UiObjects.PlayWithoutBuffsButton.onClick.AddListener(PlayWithoutBuffs);

            BuildModels();
        }

        private void PlayWithBuffs()
        {
            Debug.LogError("with");
        }

        private void PlayWithoutBuffs()
        {
            Debug.LogError("without");
        }

        private void BuildModels()
        {
            var ids = new int[]
            {
                0, 1
            };

            var hierarchies = _monoBehaviourServiceLocator.UiObjects.Hierarchies;
            var transforms = new Transform[hierarchies.Length];
            var attackButtons = new Button[hierarchies.Length];
            var animators = new Animator[hierarchies.Length];

            for (int i = 0; i < hierarchies.Length; i++)
            {
                transforms[i] = hierarchies[i].statsPanel;
                attackButtons[i] = hierarchies[i].attackButton;
                animators[i] = hierarchies[i].character;
            }

            _playerModelBuilder.Build(ids);
            _playerViewBuilder.Build(ids, animators);
            _uiBuilder.Build(ids, transforms, attackButtons);
            _attackUiSystem.Build();
        }
    }
}