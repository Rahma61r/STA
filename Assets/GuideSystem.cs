using UnityEngine;
using UnityEngine.Video;
using UnityEngine.AI;
using Fungus;
using System.Collections;


public class GuideSystem : MonoBehaviour
{
    public Flowchart flowchart;
    public VideoPlayer videoPlayer;
    public GameObject guide;
    public Transform player;
    public float followDistance = 2f;

    private NavMeshAgent guideAgent;
    private bool isFollowing = false;
    private bool hasFlowchartRun = false; // ✅ متغير جديد لضمان تشغيل الـ Flowchart مرة واحدة

    void Start()
    {
        guideAgent = guide.GetComponent<NavMeshAgent>();
        guideAgent.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFlowchartRun) // ✅ شرط إضافي
        {
            hasFlowchartRun = true; // ✅ تأكد أنه لن يعمل مرة ثانية
            StartCoroutine(StartGuideSequence());
        }
    }

    IEnumerator StartGuideSequence()
    {
        flowchart.ExecuteBlock("Start");

        while (flowchart.GetExecutingBlocks().Count > 0)
        {
            yield return null;
        }
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        guideAgent.enabled = true;
        isFollowing = true;
    }

    void Update()
    {
        if (isFollowing)
        {
            float distance = Vector3.Distance(guide.transform.position, player.position);
            if (distance > followDistance)
            {
                guideAgent.SetDestination(player.position);
            }
            else
            {
                guideAgent.ResetPath();
            }
        }
    }
}
