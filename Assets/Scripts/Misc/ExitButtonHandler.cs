using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Misc
{

    [RequireComponent(typeof(Button))]
    public class ExitButtonHandler : MonoBehaviour
    {
        private Button _exitButton;

        private void OnEnable()
        {
            _exitButton = GetComponent<Button>();
            _exitButton.onClick.AddListener(Quit);
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(Quit);
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

    }
}