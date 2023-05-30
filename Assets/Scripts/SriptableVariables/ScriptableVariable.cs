using System;
using UnityEngine;

namespace Assets.Scripts.SriptableVariables
{
    public abstract class ScriptableVariable<T> : ScriptableObject
    {
        [SerializeField]
        protected T _value;

        public virtual T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                Action?.Invoke(_value);
            }
        }

        protected Action<T> Action;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_value != null)
            {
                Action?.Invoke(Value);
            }
        }
#endif

        public virtual void AddListener(Action<T> action)
        {
            Action += action;
        }

        public virtual void RemoveListener(Action<T> action)
        {
            Action -= action;
        }

        protected virtual void Invoke(T value)
        {
            Action.Invoke(value);
        }
    }
}