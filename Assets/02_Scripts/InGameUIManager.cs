using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button doneButton;

    void Start()
    {
        exitButton.onClick.AddListener(() => onExitButtonClick());
        doneButton.onClick.AddListener(() => onDoneButtonClick());
    }

    private void onDoneButtonClick()//Done 버튼 클릭 시 작동하는 로직 구현 필요
    {

    }

    private void onExitButtonClick()
    {
        SceneManager.LoadScene("1. Lobby");
    }

}