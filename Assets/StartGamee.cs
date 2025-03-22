using UnityEngine;
using UnityEngine.UI;

public class StartGamee : MonoBehaviour
{
    public GameObject requirementsPanel; // صورة الـ Requirements

    void Start()
    {
        requirementsPanel.SetActive(true); // تأكد أن الصورة تظهر عند بدء اللعبة
    }

    public void CloseRequirements()
    {
        Debug.Log("Button Pressed! Hiding Requirements Panel..."); // لإظهار رسالة تأكيد عند الضغط
        requirementsPanel.SetActive(false); // إخفاء الصورة
    }
}
