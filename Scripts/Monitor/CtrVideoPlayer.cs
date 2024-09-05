
using UnityEngine;
using UnityEngine.Video;

public class CtrVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer; // 视频播放器组件
    private bool isPlaying = false; // 当前播放状态

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
   
        videoPlayer.loopPointReached += (vp) =>
        {
            videoPlayer.time = 0;
            isPlaying = true;
        };
        // 确保视频一开始是播放的的
        videoPlayer.Play();
     
    }

    public void TogglePlayPause()
    {
        if (!isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
        isPlaying = !isPlaying;
    }


    public void CtrlStopVideo()
    {
        videoPlayer.Pause();
    }
}
