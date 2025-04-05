using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class fungs : MonoBehaviour
{
    public Flowchart myflowchart;
   
    void OnTriggerEnter(Collider x)
    {
        if (x.gameObject.tag == "Player")
        {
            myflowchart.ExecuteBlock("dora");
        }
    }
}
