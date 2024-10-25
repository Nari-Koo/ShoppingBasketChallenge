using UnityEngine;

public class Checkout : MonoBehaviour
{
    public Cart cart; // 장바구니 객체를 참조

    // 결제 버튼이 눌렸을 때 호출되는 함수
    public void OnCheckoutButtonPressed()
    {
        float totalPrice = cart.CalculateTotalPrice();
        Debug.Log("총 가격: " + totalPrice + "원");
        cart.ClearCart(); // 결제 후 장바구니를 비움
    }
}
