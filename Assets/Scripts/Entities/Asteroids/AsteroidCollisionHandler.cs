using Assets.Scripts.Entities.Bullets;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Entities.Asteroids
{
    public class AsteroidCollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var damageable = collider.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.ApplyDamage();
            }
        }
    }
}
