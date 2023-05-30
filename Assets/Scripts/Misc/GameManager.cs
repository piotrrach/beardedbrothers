using Assets.Scripts.GameEvents;
using Assets.Scripts.SceneLoading;
using System;
using UnityEngine;

namespace Assets.Scripts.Misc
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private string _mainMenuSceneName;
        [SerializeField]
        private string _gameplaySceneName;
        [SerializeField]
        private string _gameOverSceneName;

        [SerializeField]
        private GameEvent _onStartGameButtonPress;
        [SerializeField]
        private GameEvent _onBackToMainMenuButtonPress;
        [SerializeField]
        private GameEvent _onPlayerDeath;

        private void OnEnable()
        {
            _onStartGameButtonPress.AddListener(OnStartGameButtonPress);
            _onPlayerDeath.AddListener(OnPlayerDeath);
            _onBackToMainMenuButtonPress.AddListener(OnBackToMainMenuButtonPress);
        }


        private void OnDisable()
        {
            _onStartGameButtonPress.RemoveListener(OnStartGameButtonPress);
            _onPlayerDeath.RemoveListener(OnPlayerDeath);
            _onBackToMainMenuButtonPress.RemoveListener(OnBackToMainMenuButtonPress);
        }

        private void OnBackToMainMenuButtonPress()
        {
            SceneLoader.Instance.LoadScene(_mainMenuSceneName);
        }

        private void Start()
        {
            SceneLoader.Instance.LoadScene(_mainMenuSceneName);
        }

        private void OnPlayerDeath()
        {
            SceneLoader.Instance.LoadScene(_gameOverSceneName);
        }


        private void OnStartGameButtonPress()
        {
            SceneLoader.Instance.LoadScene(_gameplaySceneName);
        }
    }

}