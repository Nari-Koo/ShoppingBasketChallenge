using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    // 장바구니에 담긴 상품들의 리스트
    public List<Product> productsInCart = new List<Product>();

    // 장바구니에 상품을 추가하는 함수
    public void AddProduct(Product product)
    {
        productsInCart.Add(product);
        //Debug.Log(product.productName + "이(가) 장바구니에 추가되었습니다.");
    }

    // 장바구니에 담긴 모든 상품들의 총 가격을 계산하는 함수
    public float CalculateTotalPrice()
    {
        float totalPrice = 0f;
        foreach (Product product in productsInCart)
        {
            totalPrice += product.price;
        }
        return totalPrice;
    }

    // 장바구니를 비우는 함수
    public void ClearCart()
    {
        productsInCart.Clear();
        Debug.Log("장바구니가 비워졌습니다.");
    }
}
