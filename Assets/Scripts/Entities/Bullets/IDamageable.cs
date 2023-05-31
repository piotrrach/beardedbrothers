using UnityEngine;

namespace Assets.Scripts.Entities.Bullets
{
    public interface IDamageable
    {
        public void ApplyDamage(int damage = 1);
    }
}
