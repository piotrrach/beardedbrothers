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
        [SerializeField]
        private EnemyMovementSettings _settings;
        [SerializeField]

        private bool _debug = true;
        private bool _strafeRight;
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

            if (Time.realtimeSinceStartup - _lastTimeStrafeDirChange > _settings.StrafeChangeInterval)
            {
                _lastTimeStrafeDirChange = Time.realtimeSinceStartup;
                _strafeRight = !_strafeRight;
            }
        }

        private void FixedUpdate()
        {
            UpdateMovement();
            Strafe();
        }

        private void UpdateMovement()
        {
            var dirToTarget = (Vector2)(_settings.FollowTarget.Value.position - transform.position).normalized;
            float sqrDistanceTarget = (_settings.FollowTarget.Value.position - transform.position).sqrMagnitude;
            float rotateVectorAngle = 360 / _settings.NumberOfScanningRays;
            Vector2 rayDir = (Quaternion.AngleAxis(0, Vector3.forward) * dirToTarget) * _settings.ScanDistance;

            Vector2 desiredDir = Vector2.zero;

            for (int i = 0; i < _settings.NumberOfScanningRays; i++)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir, _settings.ScanDistance, _settings.Evadable);
                bool isInsideOfBounds = _settings.GameplayBounds.IsInside((Vector2)transform.position + rayDir);
                if (hit.collider || !isInsideOfBounds)
                {
                    if (_debug) Debug.DrawRay((Vector2)transform.position + rayDir.normalized, rayDir, Color.red);
                    desiredDir += rayDir.normalized * hit.distance;
                }
                else
                {
                    desiredDir += rayDir;
                    if (_debug) Debug.DrawRay((Vector2)transform.position + rayDir.normalized, rayDir, Color.green);
                }

                rayDir = (Quaternion.AngleAxis(rotateVectorAngle, Vector3.forward) * rayDir);
            }

            if(sqrDistanceTarget > _settings.ScanDistance * _settings.ScanDistance)
            {
                desiredDir += dirToTarget.normalized * _settings.ScanDistance;
            }

            desiredDir = desiredDir.normalized * _settings.MovementSpeed;

            _rigidbody.AddForce(desiredDir);

        }

        void Strafe()
        {
            if (_strafeRight)
            {
                _rigidbody.AddForce(_model.right * _settings.StrafeSpeed);
            }
            else
            {
                _rigidbody.AddForce(-_model.right * _settings.StrafeSpeed);
            }
        }

    }
}
