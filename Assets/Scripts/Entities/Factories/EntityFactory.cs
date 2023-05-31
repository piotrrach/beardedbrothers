using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entities.Spawning
{
    [CreateAssetMenu(fileName = "Entity Factory", menuName = "Systems/Entity Factory")]
    public class EntityFactory : ScriptableObject
    {
        [Header("Object to be spawned")]
        [SerializeField]
        private GameObject _objectToSpawn;
        [Header("Optional, if not provided, object would spawn at (0,0)")]
        [SerializeField]
        private SpawnPositionProvider _spawnPositionProvider;

        [NonSerialized]
        private Transform _parent;
        [NonSerialized]
        private List<GameObject> _pool = new List<GameObject>();

        public GameObject Spawn()
        {
            if (_parent == null)
            {
                _parent = new GameObject($"{name} pool").transform;
            }

            Vector2 objectSpawnPosition = _spawnPositionProvider != null ? _spawnPositionProvider.GetNextSpawnPosition() : Vector3.zero;

            for (int i = 0; i < _pool.Count; i++)
            {
                if (_pool[i] == null)
                {
                    _pool.RemoveAt(i);
                    continue;
                }

                if (!_pool[i].activeSelf)
                {
                    _pool[i].transform.position = objectSpawnPosition;
                    _pool[i].SetActive(true);
                    return _pool[i];
                }
            }

            GameObject newGameObject = GameObject.Instantiate(_objectToSpawn, objectSpawnPosition, Quaternion.identity, _parent);
            _pool.Add(newGameObject);
            return newGameObject;
        }
    }
}
