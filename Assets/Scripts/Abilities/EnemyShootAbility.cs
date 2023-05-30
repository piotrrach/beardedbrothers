using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class EnemyShootAbility : ShootAbility
    {
        private void Update()
        {
            TryShoot();
        }
    }
}
