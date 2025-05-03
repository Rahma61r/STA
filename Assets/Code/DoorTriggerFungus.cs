using UnityEngine;
using Fungus;

public class SportStoreTrigger : MonoBehaviour
{
    public Flowchart sportStoreFlowchart; // اسحب الـ Flowchart هنا

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player Entered the Store!"); 
            sportStoreFlowchart.ExecuteBlock("StartDialogue"); 
        }
    }
}
