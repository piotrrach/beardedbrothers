using Assets.Scripts.SriptableVariables;
using UnityEngine;
namespace Assets.Scripts.Entities.Bullets
{
    public class BulletMovementController : MonoBehaviour
    {
        [SerializeField]
        private Transform _bulletTransform;
        [SerializeField]
        private FloatVariable _bulletVelocity;

        private void FixedUpdate()
        {
            transform.position +=  transform.up * _bulletVelocity.Value * Time.fixedDeltaTime;
        }
    }
}