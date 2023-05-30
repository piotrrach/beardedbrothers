using UnityEngine;

namespace Assets.Scripts.SriptableVariables
{
    [CreateAssetMenu(fileName = "UInt Variable", menuName = "Scriptable Variables/UInt")]
    class UIntVariable : ScriptableVariable<uint>
    {
        public void Add(int value)
        {
            Value += (uint)value;
        }

        public void Remove(int value)
        {
            Value -= (uint)value;
        }
    }
}
