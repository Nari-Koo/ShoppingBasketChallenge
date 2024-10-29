using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button doneButton;
    [SerializeField] private TMP_Text PopUp;

    private bool isProcessing = false;

    void Start()
    {
        SetupButtonListeners();
    }

    private void SetupButtonListeners()
    {
        SetupButton(doneButton, onDoneButtonClick);
        SetupButton(exitButton, onExitButtonClick);
    }

    private void SetupButton(Button button, System.Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => HandleButtonClick(action));
    }

    private async void HandleButtonClick(System.Action action)
    {
        if (isProcessing) return;
        isProcessing = true;

        action.Invoke();
        await Task.Delay(500);  // 버튼 처리 후 잠시 대기

        isProcessing = false;
    }

    private void CalTotalPrice()
    {
        if (Cart.Instance != null)
        {
            float totalPrice = Cart.Instance.CalculateTotalPrice();
            Debug.Log("총 가격: " + totalPrice + "달러");
        }
        else
        {
            Debug.LogWarning("장바구니 인스턴스를 찾을 수 없습니다.");
        }
    }

    private void onDoneButtonClick()
    {
        if (!CheckInstanceValidity()) return;

        CalTotalPrice();
        float totalPrice = Cart.Instance.CalculateTotalPrice();

        if (totalPrice == RandomPrice.Instance.randomNumber)
        {
            ChangeText("Clear!");
            ChangeSceneWithInvoke();
        }
        else
        {
            ChangeText("Fail");
            Cart.Instance.ClearCart();
        }
    }

    private bool CheckInstanceValidity()
    {
        if (Cart.Instance == null || RandomPrice.Instance == null)
        {
            Debug.LogError("Cart 또는 RandomPrice Instance를 찾을 수 없습니다.");
            return false;
        }
        return true;
    }

    public void ChangeText(string newText)
    {
        if (PopUp != null)
        {
            PopUp.text = newText;
        }
        else
        {
            Debug.LogError("PopUp 텍스트가 설정되지 않았습니다.");
        }
    }

    public async void ChangeSceneWithInvoke()
    {
        await Task.Delay(3000);  // 3초 대기
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("1. Lobby");
    }

    private void onExitButtonClick()
    {
        LoadNextScene();
    }
}