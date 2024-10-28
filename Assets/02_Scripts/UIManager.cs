using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Button level1Button;
    [SerializeField] private Button exitButton;

    void Start()
    {
        level1Button.onClick.AddListener(() => onLevel1ButtonClick());
        exitButton.onClick.AddListener(() => onExitButtonClick());
    }

    private void onLevel1ButtonClick()
    {
        SceneManager.LoadScene("2. Level 1");
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
