using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static int totalCoins = 0;

    public TextMeshProUGUI coinText;

    void Awake()
    {
        totalCoins = 0;
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        UpdateCoinText();

        Debug.Log("Coins collected: " + totalCoins);
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + totalCoins;
        }
    }
}