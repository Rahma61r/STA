using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class loader : MonoBehaviour
{
    public void LoadDemo_01Scene()
    {
        SceneManager.LoadScene("Demo_01");
    }
}
