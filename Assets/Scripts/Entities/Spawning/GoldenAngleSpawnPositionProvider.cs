using UnityEngine;

namespace Assets.Scripts.Entities.Spawning
{
    [CreateAssetMenu(fileName = "New Golden Angle Spawn Position Provider", menuName = "Spawn Position Providers/Golden Angle")]
    public class GoldenAngleSpawnPositionProvider : SpawnPositionProvider
    {
        private readonly float _goldenAngle = 137.5077f;

        private Vector2 _lastVector = Vector2.up;

        [SerializeField]
        private Bounds2D _gameplayBounds;

        private void OnEnable()
        {
            _lastVector = Vector2.up;
        }

        public override Vector2 GetNextSpawnPosition()
        {
            _lastVector = (Quaternion.AngleAxis(_goldenAngle, Vector3.forward) * _lastVector).normalized;

            Vector2 resultPosition = _lastVector;
            float maxX = _gameplayBounds.Width / 2 - 1;
            float maxY = _gameplayBounds.Height / 2 - 1;

            Vector2 VecToRightTopScreenCorner = new Vector2(_gameplayBounds.RightEdgeX, _gameplayBounds.TopEdgeY).normalized;

            if (Mathf.Abs(_lastVector.x) > Mathf.Abs(VecToRightTopScreenCorner.x))
            {
                float ratio = maxX / Mathf.Abs(_lastVector.x);
                resultPosition.x = maxX * Mathf.Sign(_lastVector.x);
                resultPosition.y *= ratio;
            }

            if(Mathf.Abs(_lastVector.y) >= Mathf.Abs(VecToRightTopScreenCorner.y))
            {
                float ratio = maxY / Mathf.Abs(_lastVector.y);
                resultPosition.y = maxY * Mathf.Sign(_lastVector.y);
                resultPosition.x *= ratio;
            }

            return resultPosition;
        }
    }
}
