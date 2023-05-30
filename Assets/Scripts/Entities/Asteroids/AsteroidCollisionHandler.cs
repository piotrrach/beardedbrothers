using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Entities.Asteroids
{
    public class AsteroidCollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var playerHealth = collision.gameObject.GetComponent<PlayerHealthHandler>();

            if (playerHealth)
            {
                playerHealth.ApplyDamage();
            }
        }
    }
}
