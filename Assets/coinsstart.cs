using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinsstart : MonoBehaviour
{

    public int playerCoins = 5;  // اللاعب يبدأ بـ 5 كوينز
    public TextMeshProUGUI coinDisplay;  // عرض الكوينز على الـ UI باستخدام TextMeshPro

    void Start()
    {
        UpdateCoinDisplay();  // عشان يظهر العدد في بداية اللعبة
    }

    public void AddCoins(int amount)
    {
        playerCoins += amount;
        UpdateCoinDisplay();
    }

    void UpdateCoinDisplay()
    {
        coinDisplay.text = ": " + playerCoins.ToString();  // عرض الكوينز في الـ UI
    }
}
