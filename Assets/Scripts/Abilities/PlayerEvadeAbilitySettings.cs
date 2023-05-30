using Assets.Scripts.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    [CreateAssetMenu(fileName = "Evade Ability Settings", menuName = "Ability Settings/Evade Ability")]
    public class PlayerEvadeAbilitySettings : ScriptableObject
    {
        [field: SerializeField]
        public int ScanningRays { get; private set; } = 60;
        [field: SerializeField]
        public float ScanDistance { get; private set; } = 15;
        [field: SerializeField]
        public float EvadeDistance { get; private set; } = 10;
        [field: SerializeField]
        public float EvadeSpeed { get; private set; } = 2f;
        [field: SerializeField]
        public GameEvent TriggerEvent { get; private set; }
        [field: SerializeField]
        public Bounds2D GameplayBounds { get; private set; }
        [field: SerializeField]
        public LayerMask EvadableLayerMask { get; private set; }
    }
}
