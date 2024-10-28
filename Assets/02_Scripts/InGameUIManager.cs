using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button doneButton;
    [SerializeField] private TMP_Text PopUp;

    private bool isProcessing = false;  // 중복 클릭 방지용

    void Start()
    {
        SetupButtonListeners();
    }

    private void SetupButtonListeners()
    {
        // 중복 이벤트 리스너 제거 및 리스너 추가
        doneButton.onClick.RemoveAllListeners();
        doneButton.onClick.AddListener(() => HandleButtonClick(onDoneButtonClick));

        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(() => HandleButtonClick(onExitButtonClick));
    }

    private void HandleButtonClick(System.Action action)
    {
        // 버튼이 여러 번 눌리지 않도록 처리
        if (isProcessing) return;
        isProcessing = true;

        action.Invoke();
        isProcessing = false;  // 처리 완료 후 해제
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
            Cart.Instance.ClearCart();  // 실패 시 장바구니 비우기
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

    public void ChangeSceneWithInvoke()
    {
        Invoke(nameof(LoadNextScene), 3.0f);  // 3초 후에 LoadNextScene 호출
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("1. Lobby");  // 씬 전환
    }

    private void onExitButtonClick()
    {
        LoadNextScene();
    }
}