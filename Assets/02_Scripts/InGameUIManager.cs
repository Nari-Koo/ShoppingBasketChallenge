using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button doneButton;

    public Cart cart; // 장바구니 객체를 참조

    void Start()
    {
        exitButton.onClick.AddListener(() => onExitButtonClick());
        doneButton.onClick.AddListener(() => onDoneButtonClick());
    }

    private void onDoneButtonClick()//Done 버튼 클릭 시 작동하는 로직 구현
    {
        float totalPrice = cart.CalculateTotalPrice();
        Debug.Log("총 가격: " + totalPrice + "원");
        cart.ClearCart(); // 결제 후 장바구니를 비움
    }

    private void onExitButtonClick()
    {
        SceneManager.LoadScene("1. Lobby");
    }

}