using Assets.Scripts.Entities.Spawning;
using Assets.Scripts.SriptableVariables;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public abstract class ShootAbility : MonoBehaviour
    {
        protected float LastShotTime;

        [SerializeField] 
        private EntityFactory _bulletsSpawner;
        [SerializeField] 
        private Transform _spawnPointMarker;
        [SerializeField] 
        protected FloatVariable _cooldown;

        public void TryShoot()
        {
            if(Time.time - LastShotTime < _cooldown.Value)
            {
                return;
            }

            GameObject bullet = _bulletsSpawner.Spawn();
            bullet.transform.position = _spawnPointMarker.transform.position;
            bullet.transform.rotation = _spawnPointMarker.transform.rotation;

            LastShotTime = Time.time;
        }
    }
}
