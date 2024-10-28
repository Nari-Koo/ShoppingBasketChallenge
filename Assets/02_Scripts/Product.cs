using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Product : MonoBehaviour
{
    public string productName;  // 상품명
    public float price;         // 상품 가격

    private Cart cart;                  // 장바구니 객체
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable; // XR Grab Interactable 컴포넌트

    private void Start()
    {
        // "Cart" 태그를 가진 게임 오브젝트에서 Cart 컴포넌트를 찾음
        GameObject cartObject = GameObject.FindWithTag("Cart");
        if (cartObject != null)
        {
            cart = cartObject.GetComponent<Cart>();
        }

        if (cart == null)
        {
            Debug.LogWarning("장바구니를 찾을 수 없습니다. 씬에 'Cart' 태그가 설정된 오브젝트가 있는지 확인하세요.");
        }

        // XR Grab Interactable 컴포넌트 설정
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabInteractable != null)
        {
            // 물건이 잡혔을 때 바로 장바구니에 추가하고 씬에서 제거
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
    }

    // 물건이 잡혔을 때 호출되는 함수
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        AddToCart();
    }

    // 장바구니에 상품을 추가하고 씬에서 제거하는 함수
    private void AddToCart()
    {
        if (cart != null)
        {
            cart.AddProduct(this);
            Debug.Log(productName + "이(가) 장바구니에 추가되었습니다.");
            Destroy(gameObject); // 상품을 장바구니에 추가한 후 씬에서 제거
        }
        else
        {
            Debug.LogWarning("장바구니를 찾을 수 없습니다.");
        }
    }

    private void OnDestroy()
    {
        // 이벤트 리스너 제거
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}
