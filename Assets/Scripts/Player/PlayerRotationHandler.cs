using Assets.Scripts.SriptableVariables;
using Assets.Scripts.InputProviding;
using UnityEngine;
namespace Assets.Scripts.Player
{
    public class PlayerRotationHandler : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerModel;
        [SerializeField]
        private InputProviderVariable _inputProvider;
        [SerializeField]
        private BoolVariable _isPlayerDead;

        private void Update()
        {
            if (_isPlayerDead.Value)
            {
                return;
            }
            _playerModel.rotation = _inputProvider.Value.GetRotation();
        }
    }
}