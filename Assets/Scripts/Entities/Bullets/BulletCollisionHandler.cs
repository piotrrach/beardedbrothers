using UnityEngine;

namespace Assets.Scripts.Entities.Bullets
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.ApplyDamage();
                gameObject.SetActive(false);
            }
        }
    }
}
