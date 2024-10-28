using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public static Cart Instance { get; private set; }
    public List<Product> productsInCart = new List<Product>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // 인스턴스 초기화
        }
        else
        {
            Destroy(gameObject);  // 중복된 인스턴스 방지
        }
    }

    public void AddProduct(Product product)
    {
        productsInCart.Add(product);
    }

    public float CalculateTotalPrice()
    {
        float totalPrice = 0f;
        foreach (Product product in productsInCart)
        {
            totalPrice += product.price;
        }
        return totalPrice;
    }

    public void ClearCart()
    {
        productsInCart.Clear();
        Debug.Log("장바구니가 비워졌습니다.");
    }
}
