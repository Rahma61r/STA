using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoButtonManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;   
    public Button playButton;       
    public VideoClip videoClip;     

    void Start()
    {
        playButton.onClick.AddListener(PlayVideo);
    }

    public void PlayVideo()
    {
        videoPlayer.clip = videoClip;
        videoPlayer.Play();           
    }
}
