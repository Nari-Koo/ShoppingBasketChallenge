using UnityEngine;

public class Product : MonoBehaviour
{
    // 상품명과 가격은 Inspector에서 설정할 수 있습니다.
    public string productName;  // 상품명
    public float price;         // 상품 가격

    // 상품이 장바구니에 담길 때 호출되는 함수
    public void AddToCart(Cart cart)
    {
        cart.AddProduct(this);
    }

    // 디버깅 용도로 상품 정보를 출력하는 함수
    public void PrintProductInfo()
    {
        Debug.Log("상품명: " + productName + ", 가격: " + price + "원");
    }
}
