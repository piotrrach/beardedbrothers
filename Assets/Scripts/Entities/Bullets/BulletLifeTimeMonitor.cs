using Assets.Scripts.SriptableVariables;
using UnityEngine;

namespace Assets.Scripts.Entities.Bullets
{
    public class BulletLifeTimeMonitor : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable _bulletLifeTime;

        private float _timeCounter;

        private void OnEnable()
        {
            _timeCounter = 0;
        }

        private void Update()
        {
            _timeCounter += Time.deltaTime;
            if(_timeCounter > _bulletLifeTime.Value)
            {
                gameObject.SetActive(false);
            }
        }

    }
}
