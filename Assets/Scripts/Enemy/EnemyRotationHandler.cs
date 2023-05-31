using Assets.Scripts.InputProviding;
using Assets.Scripts.SriptableVariables;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Scripts.Enemy
{
    public class EnemyRotationHandler : MonoBehaviour
    {
        [SerializeField]
        private TransformVariable _playerTransform;
        [SerializeField]
        private Transform _model;

        private void Update()
        {
            if (!_playerTransform || !_playerTransform.Value)
            {
                return;
            }

            var dir = _playerTransform.Value.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            _model.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
