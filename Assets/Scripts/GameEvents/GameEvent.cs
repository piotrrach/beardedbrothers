using System;
using UnityEngine;
namespace Assets.Scripts.GameEvents
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event")]
    public class GameEvent : ScriptableObject
    {
        private Action _action;

        public void AddListener(Action action)
        {
            _action += action;
        }

        public void RemoveListener(Action action)
        {
            _action -= action;
        }

        public void Invoke()
        {
            _action?.Invoke();
        }

#if UNITY_EDITOR
        private void OnGUI()
        {
            if (GUILayout.Button("Invoke"))
            {
                Invoke();
            }
        }
#endif
    }
}