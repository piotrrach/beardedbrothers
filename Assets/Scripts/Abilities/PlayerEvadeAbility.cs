using Assets.Scripts.GameEvents;
using Assets.Scripts.Player;
using System;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class PlayerEvadeAbility : MonoBehaviour
    {
        [SerializeField]
        private PlayerEvadeAbilitySettings _settings;
        [SerializeField]
        private PlayerHealthHandler playerHealthHandler;
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        [Tooltip("Draws scan rays")]
        private bool _debug;

        private float _step = 0;
        private bool _isEvaiding = false;

        private Vector2 _startEvadingPosition;
        private Vector2 _targetEvadingPosition;

        private void OnEnable()
        {
            _settings.TriggerEvent.AddListener(OnPlayerHit);
        }

        private void OnDisable()
        {
            _settings.TriggerEvent.AddListener(OnPlayerHit);
        }

        private void Update()
        {
            ScanForTheBestEvadePosition();
        }

        private void FixedUpdate()
        {
            if (!_isEvaiding)
            {
                return;
            }
            Vector2 movePosition = Vector2.Lerp(_startEvadingPosition, _targetEvadingPosition, _step);
            _step += Time.fixedDeltaTime * _settings.EvadeSpeed;
            _rigidbody2D.MovePosition(movePosition);
            _isEvaiding = _step < 1;
            playerHealthHandler.IsImmortal = _isEvaiding;
        }

        private void OnPlayerHit()
        {
            _targetEvadingPosition = ScanForTheBestEvadePosition();
            _startEvadingPosition = transform.position;
            _isEvaiding = true;
            _step = 0;
        }

        private Vector2 ScanForTheBestEvadePosition()
        {
            float rotateVectorAngle = 360 / _settings.ScanningRays;
            Vector2 rayDir = (Quaternion.AngleAxis(rotateVectorAngle / 2, Vector3.forward) * Vector2.up);
            Vector2 mostSafeDir = rayDir;

            for (int i = 0; i < _settings.ScanningRays; i++)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir, _settings.ScanDistance, _settings.EvadableLayerMask);
                if (!hit)
                {
                    bool isInsideOfBounds = _settings.GameplayBounds.IsInside((Vector2)transform.position + rayDir * _settings.EvadeDistance);
                    if (isInsideOfBounds)
                    {
                        if (_debug) Debug.DrawRay(transform.position, rayDir * _settings.ScanDistance, Color.green);
                        mostSafeDir += rayDir;
                    }
                    else
                    {
                        if(_debug) Debug.DrawRay(transform.position, rayDir * _settings.ScanDistance, Color.red);
                    }
                }
                else
                {
                    if (_debug) Debug.DrawRay(transform.position, rayDir * _settings.ScanDistance, Color.red);
                }
                rayDir = (Quaternion.AngleAxis(rotateVectorAngle, Vector3.forward) * rayDir);
            }
            Vector2 mostSavePosition = (Vector2)transform.position + mostSafeDir.normalized * _settings.EvadeDistance;

            if (_debug) Debug.DrawLine(mostSavePosition, mostSavePosition + Vector2.up, Color.yellow);

            return mostSavePosition;
        }
    }
}
