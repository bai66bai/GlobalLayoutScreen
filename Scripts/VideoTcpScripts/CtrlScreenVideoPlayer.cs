using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CtrlScreenVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer; // 视频播放器组件

    private bool isPlaying = false; // 当前播放状态


    private void OnEnable()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        videoPlayer.loopPointReached += (vp) =>
        {
            isPlaying = false;
        };
        // 确保视频一开始是暂停的
        videoPlayer.time = 0;
        videoPlayer.Pause();
        isPlaying = false;
    }
    /// <summary>
    /// 控制视频暂停播放
    /// </summary>
    public void ToggleScreenPlayPause()
    {
        if (isPlaying)
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

    private void OnDisable()
    {
         videoPlayer.loopPointReached += (vp) =>
        {
            videoPlayer.time = 0;
            isPlaying = false;
        };
    }
}
