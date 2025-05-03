using UnityEngine;
using Fungus;
using System.Collections;
using UnityEngine.AI;

public class CardPurchase : MonoBehaviour
{
    public AudioClip buySound;
    public AudioSource audioSource;
    public Flowchart fungusFlowchart;
    public GameObject character;
    public Transform[] waypoints;  // مجموعة Waypoints
    public GameObject cardToHide;  // الكارد اللي هنخفيها بعد الشراء
    private Animator characterAnimator;  // الـ Animator الخاص بالكاركتر
    private NavMeshAgent agent;

    private bool hasPurchased = false;

    void Start()
    {
        characterAnimator = character.GetComponent<Animator>();  // الحصول على الـ Animator عند بداية اللعبة
        agent = character.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float speed = agent.velocity.magnitude;
        characterAnimator.SetFloat("Speed", speed);
    }

    public void OnBuyButtonPressed()
    {
        if (hasPurchased) return;  // ميتكررش

        hasPurchased = true;

        // 1. تشغيل الصوت
        audioSource.PlayOneShot(buySound);

        // 2. تشغيل الـ Flowchart
        fungusFlowchart.ExecuteBlock("FirstCardTaskExplanation");

        agent.SetDestination(waypoints[0].transform.position);
        
        // 3. عندما ينتهي الـ Flowchart، نكمل
        // StartCoroutine(WaitForFlowchartAndMove());
    }

    private IEnumerator WaitForFlowchartAndMove()
    {
        // انتظر حتى ينتهي الـ Flowchart
        while (fungusFlowchart.HasExecutingBlocks())
        {
            yield return null;
        }

        // 4. تغيير الأنيميشن إلى "مشي"
        characterAnimator.SetBool("isWalking", true);

        // 5. خلي الكاركتر يتحرك
        //yield return StartCoroutine(MoveCharacterThroughWaypoints());

        // 6. بعد التحرك، اخفي الكارد
        cardToHide.SetActive(false);

        // 7. إعادة الأنيميشن إلى "Idle" بعد التحرك
        characterAnimator.SetBool("isWalking", false);
    }

    private IEnumerator MoveCharacterThroughWaypoints()
    {
        float speed = 1.5f;

        for (int i = 0; i < waypoints.Length; i++)
        {
            Transform target = waypoints[i];
            while (Vector3.Distance(character.transform.position, target.position) > 0.1f)
            {
                character.transform.position = Vector3.MoveTowards(character.transform.position, target.position, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
