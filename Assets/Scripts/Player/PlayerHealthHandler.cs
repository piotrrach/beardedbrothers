using Assets.Scripts.Entities.Bullets;
using Assets.Scripts.SriptableVariables;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{
    public class PlayerHealthHandler : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private IntVariable _lifesLeft;
        [SerializeField]
        private IntVariable _lifesMaksimum;

        [SerializeField]
        private BoolVariable _isPlayerDead;

        [SerializeField]
        public UnityEvent _onDamaged;

        [SerializeField]
        private UnityEvent _onDeath;

        public bool IsImmortal { get; internal set; }

        private void OnEnable()
        {
            _lifesLeft.Value = _lifesMaksimum.Value;
            _isPlayerDead.Value = false;
        }

        public void ApplyDamage(int damage = 1)
        {
            if (IsImmortal)
            {
                return;
            }
            _lifesLeft.Value -= damage;
            if (_lifesLeft.Value <= 0)
            {
                _isPlayerDead.Value = true;
                _onDeath.Invoke();
            }
            else
            {
                _onDamaged.Invoke();
            }
        }
    }
}