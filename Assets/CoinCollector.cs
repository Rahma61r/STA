using UnityEngine;
using TMPro; // استيراد مكتبة TextMeshPro

public class CoinCollector : MonoBehaviour
{
    public int coins = 0; // عدد العملات
    public TMP_Text coinText; // استخدام TMP_Text بدلاً من Text

    void Start()
    {
        UpdateCoinUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) // التحقق إذا لمس اللاعب Coin
        {
            coins++; // زيادة عدد العملات
            UpdateCoinUI(); // تحديث النص في الـ UI
            Destroy(other.gameObject); // حذف العملة بعد جمعها
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = ": " + coins; // تحديث عدد العملات في الـ UI
        }
    }
}
