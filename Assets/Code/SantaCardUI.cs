using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SantaCardUI : MonoBehaviour
{
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private GameObject cardPanel;


    public void OnBuyButtonClicked()
    {
        // أخفي الكارد
        cardPanel.SetActive(false);

        // أظهر الأسهم
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(true);
        }

        // خصم الكوينز لو عندك نظام عملات (اختياري)
        // PlayerCoins.Instance.Deduct(10);
    }
}

