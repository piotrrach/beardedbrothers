using Assets.Scripts.Entities.Bullets;
using Assets.Scripts.SriptableVariables;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField]
        public IntVariable _initialHealth;

        [SerializeField]
        public UnityEvent _onDamaged;

        [SerializeField]
        private UnityEvent _onDeath;

        public int HP { get; private set; }

        private void OnEnable()
        {
            HP = _initialHealth.Value;
        }

        public void ApplyDamage(int damage = 1)
        {
            HP -= damage;
            if(HP > 0)
            {
                _onDamaged.Invoke();
            }
            else
            {
                _onDeath.Invoke();
            }
        }
    }
}
