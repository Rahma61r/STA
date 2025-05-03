using UnityEngine;
using UnityEngine.UI;  // تأكد من إضافة UnityEngine.UI
using TMPro;  // تأكد من إضافة TMPro

public class QuizManager : MonoBehaviour
{
    // ربط UI في السكربت
    public InputField emailInput;  // حقل إدخال الإيميل
    public TMP_Text coinsText;         // نص عملات اللاعب
    public Button submitButton;    // زر تقديم الإجابات
    public Button closeButton;     // زر الإغلاق
    public GameObject quizUI;      // الـ UI الخاص بالكويز

    // النقاط
    private int coins = 0;

    // التوجلات للإجابات (كل سؤال له Toggle Group)
    public Toggle question1YesToggle;  // توغل الإجابة "نعم" للسؤال الأول
    public Toggle question1NoToggle;   // توغل الإجابة "لا" للسؤال الأول

    public Toggle question2YesToggle;  // توغل الإجابة "نعم" للسؤال الثاني
    public Toggle question2NoToggle;   // توغل الإجابة "لا" للسؤال الثاني

    public Toggle question3YesToggle;  // توغل الإجابة "نعم" للسؤال الثالث
    public Toggle question3NoToggle;   // توغل الإجابة "لا" للسؤال الثالث

    // Start is called before the first frame update
    void Start()
    {
        // تأكد من أن الـ UI الخاص بالكويز معطل بداية اللعبة
        quizUI.SetActive(false);

        // تعيين الحدث عند الضغط على زر Submit
        submitButton.onClick.AddListener(CheckAnswers);

        // تعيين الحدث عند الضغط على زر Close
        closeButton.onClick.AddListener(CloseQuiz);
    }

    // هذه الدالة تتأكد من الإجابات
    void CheckAnswers()
    {
        bool isAnswerCorrect = true;

        // تحقق من الإجابة الأولى (نعم / لا)
        if (!question1YesToggle.isOn)  // على سبيل المثال، الإجابة الصحيحة هي "نعم"
        {
            isAnswerCorrect = false;
        }

        // تحقق من الإجابة الثانية (نعم / لا)
        if (!question2YesToggle.isOn)  // الإجابة الصحيحة هي "نعم"
        {
            isAnswerCorrect = false;
        }

        // تحقق من الإجابة الثالثة (نعم / لا)
        if (!question3YesToggle.isOn)  // الإجابة الصحيحة هي "نعم"
        {
            isAnswerCorrect = false;
        }

        // إذا كانت الإجابة صحيحة
        if (isAnswerCorrect)
        {
            coins += 10;  // إضافة 10 عملات إذا كانت الإجابة صحيحة
            coinsText.text = "Coins: " + coins.ToString();  // تحديث النص الذي يعرض عدد العملات
        }
        else
        {
            // إذا كانت الإجابة خاطئة
            coinsText.text = "Try Again!";
        }
    }

    // هذه الدالة لعرض الكويز
    public void ShowQuiz()
    {
        quizUI.SetActive(true);  // تفعيل الـ UI الخاص بالكويز
    }

    // هذه الدالة لإغلاق الكويز عند الضغط على زر Close (X)
    void CloseQuiz()
    {
        quizUI.SetActive(false);  // إخفاء الـ UI الخاص بالكويز
    }

    // دالة لمس الكائن لعرض الكويز
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // تأكد من أن الكائن هو اللاعب
        {
            ShowQuiz();  // عرض الكويز
        }
    }
}
