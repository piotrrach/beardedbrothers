using UnityEngine;

namespace Assets.Scripts.SriptableVariables
{
    public abstract class ScriptableVariableSetter<T1, T2> : MonoBehaviour where T1 : ScriptableVariable<T2>
    {
        [SerializeField]
        private T1 _variable;
        [SerializeField]
        private T2 _value;

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
                SetVariableValue(_value);
            }
        }
        private void Start()
        {
            if (_mode == Mode.OnStart)
            {
                SetVariableValue(_value);
            }
        }

        private void OnEnable()
        {
            if (_mode == Mode.OnEnable)
            {
                SetVariableValue(_value);
            }
        }

        private void Update()
        {
            if (_mode == Mode.OnFirstUpdate && !_hasBeenSetOnFirstUpdate)
            {
                SetVariableValue(_value);
                _hasBeenSetOnFirstUpdate = true;
            }
            else if (_mode == Mode.EveryUpdate)
            {
                SetVariableValue(_value);
            }
        }

        private void FixedUpdate()
        {
            if (_mode == Mode.OnFirstFixedUpdate && !_hasBeenSetOnFirstFixedUpdate)
            {
                SetVariableValue(_value);
                _hasBeenSetOnFirstUpdate = true;
            }
            else if (_mode == Mode.EveryFixedUpdate)
            {
                SetVariableValue(_value);
            }
        }

        private void OnDisable()
        {
            if (_mode == Mode.OnDisable)
            {
                SetVariableValue(_value);
            }
        }

        private void OnDestroy()
        {
            if (_mode == Mode.OnDestroy)
            {
                SetVariableValue(_value);
            }
        }

        public virtual void SetVariableValue(T2 value)
        {
            _variable.Value = value;
        }

    }
}