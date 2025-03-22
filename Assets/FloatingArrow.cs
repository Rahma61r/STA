using UnityEngine;

public class FloatingArrow : MonoBehaviour
{
    public float floatSpeed = 1f;  // سرعة الحركة
    public float floatHeight = 0.5f; // مدى الارتفاع والانخفاض

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // احفظ المكان الأصلي
    }

    void Update()
    {
        // حركة السهم لأعلى وأسفل باستخدام Sine Wave
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatHeight, 0);
    }
}
