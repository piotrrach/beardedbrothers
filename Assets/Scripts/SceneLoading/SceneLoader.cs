using Assets.Scripts.SriptableVariables;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.SceneLoading
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance;

        [SerializeField]
        private BoolVariable _isSceneBeeingLoaded;

        private string _currentScene;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                Debug.LogWarning("There should be only one Scene Loader singleton shared by all scenes.");
                return; 
            }
            Instance = this;
        }

        public void LoadScene(string sceneName)
        {
            if (_isSceneBeeingLoaded.Value)
            {
                throw new System.Exception("Tried to load scene before the other was fully loaded, this is not supported");
            }

            StartCoroutine(GetEnumerator(sceneName));
        }

        IEnumerator GetEnumerator(string sceneName)
        {
            _isSceneBeeingLoaded.Value = true;

            if (!string.IsNullOrEmpty(_currentScene)){
                AsyncOperation ascynUnload = SceneManager.UnloadSceneAsync(_currentScene);
                while (!ascynUnload.isDone)
                {
                    yield return null;
                }
            }

            _currentScene = sceneName;
            AsyncOperation ascynLoad = SceneManager.LoadSceneAsync(_currentScene, LoadSceneMode.Additive);

            while (!ascynLoad.isDone)
            {
                yield return null;
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_currentScene));

            _isSceneBeeingLoaded.Value = false;
        }

    }



}
