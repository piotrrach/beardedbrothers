using Assets.Scripts.Entities.Bullets;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollisionHandler : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collider)
        {
            var damageable = collider.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.ApplyDamage();
            }
        }
    }
}
