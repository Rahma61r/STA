using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallCollector : MonoBehaviour
{
    public TextMeshProUGUI counterText; // بدل Text
    public int maxBalls = 9;
    private int ballCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && ballCount < maxBalls)
        {
            ballCount++;

            // عداد الكرات
            counterText.text = ballCount.ToString();

            // تغيير لون الكرة
            HighlightBall(other.gameObject);

            // منع احتساب الكرة مرتين
            other.tag = "Untagged";
        }
    }

    void HighlightBall(GameObject ball)
    {
        Renderer rend = ball.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.yellow; // مثال: يخلي الكرة تصفر
        }
    }
}
