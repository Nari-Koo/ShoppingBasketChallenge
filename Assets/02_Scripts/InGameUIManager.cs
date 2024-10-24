using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(() => onExitButtonClick());
    }

    private void onExitButtonClick()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}