using Assets.Scripts.SriptableVariables;
using Assets.Scripts.InputProviding;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Scripts.Player
{
    public class MovementHandler : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _playerRigidbody;
        [SerializeField]
        private FloatVariable _playerMovementVelocity;
        [SerializeField]
        private InputProviderVariable _inputProvider;
        [SerializeField]
        private BoolVariable _isPlayerDead;

        private void FixedUpdate()
        {
            if (_isPlayerDead.Value)
            {
                return;
            }
            var force = (Vector3)_inputProvider.Value.GetMovementVector() * _playerMovementVelocity.Value;
            _playerRigidbody.AddForce(force);
        }

    }
}
