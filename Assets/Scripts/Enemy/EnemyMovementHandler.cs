using Assets.Scripts.InputProviding;
using Assets.Scripts.SriptableVariables;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMovementHandler : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private Transform _model;
        [SerializeField]
        private BoolVariable _isPlayerDead;

        private bool _strafeRight;
        private float _strafePower = 12;
        private float _strafeChangeInterval = 0.8f;
        private float _lastTimeStrafeDirChange;

        private void OnEnable()
        {
            _lastTimeStrafeDirChange = Time.time;
        }

        private void Update()
        {
            if (_isPlayerDead.Value)
            {
                return;
            }

            if (Time.realtimeSinceStartup - _lastTimeStrafeDirChange > _strafeChangeInterval)
            {
                _lastTimeStrafeDirChange = Time.realtimeSinceStartup;
                _strafeRight = !_strafeRight;
            }
        }

        private void FixedUpdate()
        {
            if (_isPlayerDead.Value)
            {
                return;
            }
            Strafe();
        }

        void Strafe()
        {
            if (_strafeRight)
            {
                _rigidbody.AddForce(_model.right * _strafePower);
            }
            else
            {
                _rigidbody.AddForce(-_model.right * _strafePower);
            }
        }



    }
}
