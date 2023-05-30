using Assets.Scripts.Systems.Entities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    [CreateAssetMenu(fileName = "New Level Data", menuName = "Systems/Level Data")]
    public class LevelData : ScriptableObject
    {
        [SerializeField]
        private List<EntitySet> _entitySetsToBeSpawned = new List<EntitySet>();

        [Serializable]
        class EntitySet
        {
            [field: SerializeField]
            public EntityType EntityType { get; private set; }
            [field: SerializeField]
            public int NumberOfEntities { get; private set; }
        }

        public void LoadLevel()
        {
            foreach(var entitySet in _entitySetsToBeSpawned)
            {
                for (int i = 0; i < entitySet.NumberOfEntities; i++)
                {
                    entitySet.EntityType.Spawner.Spawn();
                }
            }
        }
    }

}
