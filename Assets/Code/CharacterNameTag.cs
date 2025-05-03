using TMPro;
using UnityEngine;

public class CharacterNameTag : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0); // عكس الاتجاه
    }
}



