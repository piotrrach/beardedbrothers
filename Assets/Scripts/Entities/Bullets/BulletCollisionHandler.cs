using UnityEngine;

namespace Assets.Scripts.Entities.Bullets
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var healthOfCollision = collision.gameObject.GetComponent<Health>();
            if (healthOfCollision)
            {
                healthOfCollision.ApplyDamage();
                gameObject.SetActive(false);
            }
        }
    }
}
