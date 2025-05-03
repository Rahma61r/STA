using UnityEngine;
using UnityEngine.UI;  // لاستخدام UI Text

public class CoinManager : MonoBehaviour
{
    public int totalCoins = 0;  // إجمالي الكوينز
    public Text coinsText;      // النص اللي هيعرض الكوينز على الشاشة
    public GameObject employeeCard; // كارت الموظف
    public int taskPrice = 10;  // سعر فتح المهمة

    private void Start()
    {
        UpdateCoinDisplay();  // تحديث عرض الكوينز
    }

    // هذه الوظيفة ستحدث عرض الكوينز
    void UpdateCoinDisplay()
    {
        coinsText.text = "Coins: " + totalCoins.ToString();  // عرض عدد الكوينز
    }

    // هذه الوظيفة لشراء المهمة
    public void TryBuyTask()
    {
        if (totalCoins >= taskPrice)  // لو الكوينز كافية
        {
            totalCoins -= taskPrice;  // خصم الكوينز
            UpdateCoinDisplay();      // تحديث عرض الكوينز
            // فتح المهمة هنا
            employeeCard.SetActive(true);  // نعرض الكارت لو الكوينز كافية
        }
        else
        {
            // لو الكوينز مش كافية
            Debug.Log("Not enough coins!");
        }
    }

    // لو اللاعب جمع كوينز جديدة
    public void AddCoins(int amount)
    {
        totalCoins += amount;
        UpdateCoinDisplay();  // تحديث عرض الكوينز بعد إضافة الكوينز
    }
}

