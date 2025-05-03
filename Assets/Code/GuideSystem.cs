using UnityEngine;
using Fungus;
using System.Collections;

public class GuideSystem : MonoBehaviour
{
    public Flowchart flowchart;
    public GameObject guide;
    public Transform player;

    private bool hasFlowchartRun = false; // لضمان تشغيل الـ Flowchart مرة واحدة فقط

    void Start()
    {
        // تأكد من أن الجايد ظاهر
        guide.SetActive(true); // يمكنك ضبط الجايد ليكون ظاهر من البداية
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFlowchartRun) // فقط إذا لم يتم تشغيل الـ Flowchart من قبل
        {
            hasFlowchartRun = true; // تأكد أنه لن يعمل مرة ثانية
            StartCoroutine(StartGuideSequence());
        }
    }

    IEnumerator StartGuideSequence()
    {
        flowchart.ExecuteBlock("Start"); // تشغيل الـ Flowchart

        while (flowchart.GetExecutingBlocks().Count > 0) // الانتظار حتى ينتهي الـ Flowchart
        {
            yield return null;
        }

        // لا يحدث شيء آخر بعد تشغيل الـ Flowchart
    }
}
