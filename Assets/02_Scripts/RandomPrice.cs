using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class RandomPrice : MonoBehaviour
{
    public static RandomPrice Instance { get; private set; }
    public TextMeshProUGUI textMeshPro;
    public int randomNumber;

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

    void Start()
    {
        randomNumber = Random.Range(15, 51); // Generates a number between 15 and 50 inclusive
        SetRandomText();
    }

    void SetRandomText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = randomNumber.ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI가 설정되지 않았습니다.");
        }
    }
}
