using Assets.Scripts.Entities.Spawning;
using Assets.Scripts.SriptableVariables;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public abstract class ShootAbility : MonoBehaviour
    {
        [SerializeField] 
        private EntityFactory _bulletsSpawner;
        [SerializeField] 
        private Transform _spawnPointMarker;
        [SerializeField] 
        private FloatVariable _cooldown;

        private float _lastShotTime;

        public void TryShoot()
        {
            if(Time.time - _lastShotTime < _cooldown.Value)
            {
                return;
            }

            GameObject bullet = _bulletsSpawner.Spawn();
            bullet.transform.position = _spawnPointMarker.transform.position;
            bullet.transform.rotation = _spawnPointMarker.transform.rotation;

            _lastShotTime = Time.time;
        }
    }
}
