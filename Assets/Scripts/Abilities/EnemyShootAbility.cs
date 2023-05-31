using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class EnemyShootAbility : ShootAbility
    {
        private void OnEnable()
        {
            LastShotTime = Time.time;
        }

        private void Update()
        {
            TryShoot();
        }
    }
}
