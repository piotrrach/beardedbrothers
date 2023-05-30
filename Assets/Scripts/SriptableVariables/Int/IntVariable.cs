using UnityEngine;

namespace Assets.Scripts.SriptableVariables
{
    [CreateAssetMenu(fileName = "Int Variable", menuName = "Scriptable Variables/Int")]
    public class IntVariable : ScriptableVariable<int>
    {
        public void Add(int value)
        {
            Value += value;
        }

        public void Remove(int value)
        {
            Value -= value;
        }
    }
}