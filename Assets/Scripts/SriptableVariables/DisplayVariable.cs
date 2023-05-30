using Assets.Scripts.SriptableVariables;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public abstract class DisplayVariable<T1,T2> : MonoBehaviour where T1 : ScriptableVariable<T2>
    {
        private TMP_Text _text;

        [SerializeField]
        private T1 _variable;
        [SerializeField]
        private string prefix;
        [SerializeField]
        private string suffix;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            OnVariableValueChanged(_variable.Value);
        }

        private void OnEnable()
        {
            _variable.AddListener(OnVariableValueChanged);
        }

        private void OnDisable()
        {
            _variable.RemoveListener(OnVariableValueChanged);
        }

        private void OnVariableValueChanged(T2 value)
        {
            _text.SetText($"{prefix}{value}{suffix}");
        }
    }
}