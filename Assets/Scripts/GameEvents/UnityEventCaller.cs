using Assets.Scripts.SriptableVariables;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameEvents
{
    public class UnityEventCaller : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _event;

        [SerializeField]
        private Mode _mode;

        private bool _hasBeenSetOnFirstUpdate = false;
        private bool _hasBeenSetOnFirstFixedUpdate = false;

        enum Mode
        {
            OnAwake,
            OnStart,
            OnEnable,
            OnFirstUpdate,
            OnFirstFixedUpdate,
            EveryUpdate,
            EveryFixedUpdate,
            OnDisable,
            OnDestroy
        }

        private void Awake()
        {
            if (_mode == Mode.OnAwake)
            {
                _event.Invoke();
            }
        }
        private void Start()
        {
            if (_mode == Mode.OnStart)
            {
                _event.Invoke();
            }
        }

        private void OnEnable()
        {
            if (_mode == Mode.OnEnable)
            {
                _event.Invoke();
            }
        }

        private void Update()
        {
            if (_mode == Mode.OnFirstUpdate && !_hasBeenSetOnFirstUpdate)
            {
                _event.Invoke();
                _hasBeenSetOnFirstUpdate = true;
            }
            else if (_mode == Mode.EveryUpdate)
            {
                _event.Invoke();
            }
        }

        private void FixedUpdate()
        {
            if (_mode == Mode.OnFirstFixedUpdate && !_hasBeenSetOnFirstFixedUpdate)
            {
                _event.Invoke();
                _hasBeenSetOnFirstUpdate = true;
            }
            else if (_mode == Mode.EveryFixedUpdate)
            {
                _event.Invoke();
            }
        }

        private void OnDisable()
        {
            if (_mode == Mode.OnDisable)
            {
                _event.Invoke();
            }
        }

        private void OnDestroy()
        {
            if (_mode == Mode.OnDestroy)
            {
                _event.Invoke();
            }
        }

    }
}

