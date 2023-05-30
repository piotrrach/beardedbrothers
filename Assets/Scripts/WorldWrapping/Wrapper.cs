using Assets.Scripts.Entities.Bullets;
using Assets.Scripts.SriptableVariables;
using UnityEngine;

namespace Assets.Scripts.WorldWrapping
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Wrapper : MonoBehaviour
    {
        private BoxCollider2D _boxCollider;
        [SerializeField]
        private Bounds2D _gameplayAreaBounds;

        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider2D>();

            _boxCollider.size = new Vector2(_gameplayAreaBounds.Width, _gameplayAreaBounds.Height);
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            Vector2 newPos = collider.transform.position;
            if (collider.transform.position.y < _boxCollider.transform.position.y - _boxCollider.size.y / 2)
            {
                newPos.y = _boxCollider.transform.position.y + _boxCollider.size.y / 2;
            }

            if(collider.transform.position.y > _boxCollider.transform.position.y + _boxCollider.size.y / 2)
            {
                newPos.y = _boxCollider.transform.position.y - _boxCollider.size.y / 2;
            }

            if(collider.transform.position.x <  _boxCollider.transform.position.x - _boxCollider.size.x / 2)
            {
                newPos.x = _boxCollider.transform.position.x + _boxCollider.size.x / 2;
            }

            if (collider.transform.position.x > _boxCollider.transform.position.x + _boxCollider.size.x / 2)
            {
                newPos.x = _boxCollider.transform.position.x - _boxCollider.size.x / 2;
            }
            collider.transform.position = newPos;
        }
    }
}
