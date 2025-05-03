using UnityEngine;

public class DoorSoundTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip firstClip;
    public AudioClip secondClip;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            StartCoroutine(PlaySoundsInOrder());
        }
    }

    private System.Collections.IEnumerator PlaySoundsInOrder()
    {
        // شغل الصوت الأول
        audioSource.clip = firstClip;
        audioSource.Play();

        // استنى لحد ما يخلص
        yield return new WaitForSeconds(firstClip.length);

        // شغل الصوت التاني
        audioSource.clip = secondClip;
        audioSource.Play();
    }
}
