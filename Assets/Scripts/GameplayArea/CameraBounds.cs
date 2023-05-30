using Assets.Scripts.SriptableVariables;
using UnityEngine;

namespace Assets.Scripts.GameplayArea
{
    [CreateAssetMenu(fileName = "New Camera Bounds", menuName = "Bounds 2D/Camera Bounds 2D")]
    public class CameraBounds : Bounds2D
    {
        [SerializeField]
        private CameraVariable _cameraVariable;

        public override float TopEdgeY => _cameraVariable.Value.transform.position.y + _cameraVariable.Value.orthographicSize;
        public override float BottomEdgeY => _cameraVariable.Value.transform.position.y - _cameraVariable.Value.orthographicSize;
        public override float LeftEdgeX => _cameraVariable.Value.transform.position.x - _cameraVariable.Value.orthographicSize * _cameraVariable.Value.aspect;
        public override float RightEdgeX => _cameraVariable.Value.transform.position.x + _cameraVariable.Value.orthographicSize * _cameraVariable.Value.aspect;
        public override float Height => _cameraVariable.Value.orthographicSize * 2;
        public override float Width => _cameraVariable.Value.aspect * _cameraVariable.Value.orthographicSize * 2;
        public override Vector2 Center => _cameraVariable.Value.transform.position;
    }
}
