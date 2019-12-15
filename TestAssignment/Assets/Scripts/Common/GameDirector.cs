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

        public GameDirector(IPlayerModelBuilder playerModelBuilder, IPlayerViewBuilder playerViewBuilder, IUiBuilder uiBuilder,
            MonoBehaviourServiceLocator monoBehaviourServiceLocator)
        {
            _playerModelBuilder = playerModelBuilder;
            _playerViewBuilder = playerViewBuilder;
            _uiBuilder = uiBuilder;
            _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
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
        }
    }

    public class AttackUiSystem
    {
        private readonly IUiModelDatabase _uiModelDatabase;

        public AttackUiSystem(IUiModelDatabase uiModelDatabase)
        {
            _uiModelDatabase = uiModelDatabase;
        }

        public void Build()
        {
            foreach (var item in _uiModelDatabase.All)
            {
                item.Value.OnButtonPressed += OnButtonPressed;
            }
        }

        private void OnButtonPressed(int id)
        {
        }
    }
}