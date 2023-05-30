using Assets.Scripts.SriptableVariables;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Entities
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        public FloatVariable _initialHealth;

        [SerializeField]
        public UnityEvent _onDamaged;

        [SerializeField]
        private UnityEvent _onDeath;

        public float HP { get; private set; }

        private void OnEnable()
        {
            HP = _initialHealth.Value;
        }

        public virtual void ApplyDamage(float damage = 1)
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
