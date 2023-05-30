using Assets.Scripts.Player;
using Assets.Scripts.SriptableVariables;
using UnityEngine;
namespace Assets.Scripts.Entities.Asteroids
{
    public class AsteroidMovementHandler : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable _asteroidSpeed;
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        private void OnEnable()
        {
            var movementDirection = Random.insideUnitCircle;
            _rigidbody2D.AddForce(movementDirection * _asteroidSpeed.Value, ForceMode2D.Impulse);
        }
    }
}