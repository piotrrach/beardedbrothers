using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameEvents
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField]
        private GameEvent _gameEvent;

        [SerializeField]
        private UnityEvent _response;

        private void OnEnable()
        {
            _gameEvent.AddListener(OnEventInvoked);
        }

        private void OnDisable()
        {
            _gameEvent.RemoveListener(OnEventInvoked);
        }

        private void OnEventInvoked()
        {
            _response.Invoke();
        }

    }
}
