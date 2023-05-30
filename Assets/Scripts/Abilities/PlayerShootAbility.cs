using Assets.Scripts.InputProviding;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class PlayerShootAbility : ShootAbility
    {
        [SerializeField]
        private InputProvider _inputProvider;

        private void Update()
        {
            if (_inputProvider.GetShootIntent())
            {
                TryShoot();
            }
        }
    }
}
