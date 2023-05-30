using Assets.Scripts.SriptableVariables;
using UnityEngine;

namespace Assets.Scripts.InputProviding
{
    [CreateAssetMenu(fileName = "PC Input Provider", menuName = "Input Provider/PC")]
    internal class PCInputProvider : InputProvider
    {
        private Vector2 _movementVector;

        [SerializeField]
        private TransformVariable _player;

        public override Quaternion GetRotation()
        {
            var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _player.Value.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public override Vector2 GetMovementVector()
        {
            _movementVector = Vector2.zero;
            _movementVector.x += (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) ? -1 : 0;
            _movementVector.x += (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) ? +1 : 0;
            _movementVector.y += (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) ? +1 : 0;
            _movementVector.y += (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? -1 : 0;
            return _movementVector.normalized;
        }

        public override bool GetShootIntent()
        {
            return Input.GetKey(KeyCode.Mouse0);
        }
    }
}
