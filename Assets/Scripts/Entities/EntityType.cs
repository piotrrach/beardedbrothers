using Assets.Scripts.Entities;
using Assets.Scripts.Entities.Spawning;
using UnityEngine;

namespace Assets.Scripts.Systems.Entities
{
    [CreateAssetMenu(fileName = "New Entity Type", menuName = "Entities/Entity Type")]
    public class EntityType : ScriptableObject
    {
        [field: SerializeField]
        public GameObject GameObject { get; private set; }

        [field: SerializeField]
        public EntityFactory Spawner { get; private set; }
    }
}
