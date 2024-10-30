using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class RandomPrice : MonoBehaviour
{
    public static RandomPrice Instance { get; private set; }
    public TextMeshProUGUI textMeshPro;

    public static int persistentRandomNumber;  // 랜덤 가격 저장
    public int randomNumber;

    // 실패 시 가격 유지 여부를 제어하는 플래그
    public static bool shouldKeepPrice = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 전환 시 객체 유지
        }
        else
        {
            Destroy(gameObject);  // 중복 방지
        }
    }

    void Start()
    {
        if (shouldKeepPrice && persistentRandomNumber != 0)
        {
            randomNumber = persistentRandomNumber;  // 기존 랜덤 가격 사용
        }
        else
        {
            randomNumber = Random.Range(15, 51);  // 새로운 랜덤 값 생성
            persistentRandomNumber = randomNumber;  // 정적 변수에 저장
        }

        SetRandomText();
    }

    void SetRandomText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = randomNumber.ToString();  // UI에 텍스트 표시
        }
        else
        {
            Debug.LogError("TextMeshProUGUI가 설정되지 않았습니다.");
        }
    }

    // 가격 유지 플래그 초기화 메서드
    public static void ResetPriceFlag()
    {
        shouldKeepPrice = false;  // 가격 유지 비활성화
        persistentRandomNumber = 0;  // 저장된 가격 초기화
    }
}
