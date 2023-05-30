using Assets.Scripts.SriptableVariables;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.SceneLoading
{
    [RequireComponent(typeof(Image))]  
    public class LoadingScreenHandler : MonoBehaviour
    {
        [SerializeField]
        private BoolVariable _isSceneBeeingLoaded;

        private Image _graphic;

        private void Awake()
        {
            _graphic = GetComponent<Image>();
        }

        public void OnEnable()
        {
            _isSceneBeeingLoaded.AddListener(OnSceneLoadingStateChanged);
            OnSceneLoadingStateChanged(_isSceneBeeingLoaded.Value);
        }

        private void OnDisable()
        {
            _isSceneBeeingLoaded.RemoveListener(OnSceneLoadingStateChanged);
        }

        private void OnSceneLoadingStateChanged(bool isSceneBeeingLoaded)
        {
            _graphic.enabled = isSceneBeeingLoaded;
        }
    }
}
