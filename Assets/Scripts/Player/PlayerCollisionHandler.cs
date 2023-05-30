using Assets.Scripts.Entities;
using Assets.Scripts.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollisionHandler : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collider)
        {
            var healthOfCollision = collider.gameObject.GetComponent<Health>();
            if (healthOfCollision)
            {
                healthOfCollision.ApplyDamage(float.MaxValue);
            }
        }
    }
}
