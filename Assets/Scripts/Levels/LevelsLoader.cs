using Assets.Scripts.SriptableVariables;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public class LevelsLoader : MonoBehaviour
    {
        [SerializeField]
        private List<LevelData> levels = new List<LevelData>();

        [SerializeField]
        private UIntVariable _asteroidsNumber;

        [SerializeField]
        private IntVariable _currentLevel;

        private void OnEnable()
        {
            _asteroidsNumber.Value = 0;
            _asteroidsNumber.AddListener(OnAsteroidsNumberChange);

            _currentLevel.Value = 1;
            levels[_currentLevel.Value - 1].LoadLevel();
        }

        private void OnDisable()
        {
            _asteroidsNumber.RemoveListener(OnAsteroidsNumberChange);
        }

        private void OnAsteroidsNumberChange(uint asteroidNumber)
        {
            if (asteroidNumber == 0)
            {
                _currentLevel.Value++;
                if (_currentLevel.Value >= levels.Count)
                {
                    levels[levels.Count - 1].LoadLevel();
                }
                else
                {
                    levels[_currentLevel.Value - 1].LoadLevel();
                }
            }
        }
    }
}
