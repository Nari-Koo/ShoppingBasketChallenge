using UnityEngine;
using TMPro;

public class RandomPrice : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        SetRandomText();
    }

    void SetRandomText()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(15, 51); // Generates a number between 15 and 50 inclusive
        textMeshPro.text = randomNumber.ToString();
    }
}
