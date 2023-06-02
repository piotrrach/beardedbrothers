using Assets.Scripts.SriptableVariables;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [CreateAssetMenu(fileName = "New Enemy Movement Settings", menuName = "Enemy Settings/Movement")]
    public class EnemyMovementSettings : ScriptableObject
    {
        [field: Header("Common")]
        [field: SerializeField]
        public float MovementSpeed { get; private set; } = 50;
        [field: SerializeField]
        public TransformVariable FollowTarget { get; private set; }

        [field: SerializeField]
        [field: Header("Strafing")]
        public float StrafeSpeed { get; private set; } = 18;
        [field: SerializeField]
        public float StrafeChangeInterval { get; private set; } = 0.8f;

        [field: Header("Object evading")]
        [field: SerializeField]
        public int NumberOfScanningRays { get; private set; } = 30;
        [field: SerializeField]
        public float ScanDistance { get; private set; } = 6;
        [field: SerializeField]
        public LayerMask Evadable { get; private set; } = -1;
        [field: SerializeField]
        public Bounds2D GameplayBounds { get; private set; }
    }
}
