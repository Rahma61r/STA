using UnityEngine;
using TMPro;

public class BoxInteraction : MonoBehaviour
{
    public Transform player;        // المرجع للاعب
    public float moveSpeed = 5f;    // سرعة الحركة
    public TextMeshProUGUI hintText;  // لعرض التعليمات
    private bool isHoldingBox = false;  // هل اللاعب يحمل الصندوق؟
    private Transform originalParent;   // حفظ مكان الصندوق الأصلي

    private void Update()
    {
        // عندما يكون اللاعب قريب من الصندوق، نعرض التعليمات
        if (Vector3.Distance(player.position, transform.position) < 3f)
        {
            if (!isHoldingBox)
            {
                hintText.text = "اضغط R لتحميل الصندوق";
            }
            else
            {
                hintText.text = "اضغط T لوضع الصندوق";
            }

            // إذا ضغط اللاعب على R لتحميل الصندوق
            if (Input.GetKeyDown(KeyCode.R) && !isHoldingBox)
            {
                isHoldingBox = true;
                originalParent = transform.parent;  // حفظ المكان الأصلي للصندوق
                transform.SetParent(player);  // جعل الصندوق طفلاً للاعب
                hintText.text = "اضغط T لوضع الصندوق";  // تغيير النص
            }
        }
        else
        {
            // إذا ابتعد اللاعب عن الصندوق، النص غير مرئي
            hintText.text = "";
        }

        // إذا كان اللاعب يحمل الصندوق، يمكنه تحريكه مع الضغط على R
        if (isHoldingBox)
        {
            // تحريك الصندوق مع اللاعب
            transform.position = player.position;  // وضع الصندوق في نفس مكان اللاعب
        }

        // إذا ضغط اللاعب على T لوضع الصندوق
        if (isHoldingBox && Input.GetKeyDown(KeyCode.T))
        {
            isHoldingBox = false;
            transform.SetParent(originalParent);  // إعادة الصندوق إلى مكانه الأصلي
            hintText.text = "تم وضع الصندوق في مكانه!";
        }
    }
}
