using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CtrlScreenVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer; // ��Ƶ���������

    private bool isPlaying = false; // ��ǰ����״̬


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
        // ȷ����Ƶһ��ʼ����ͣ��
        videoPlayer.time = 0;
        videoPlayer.Pause();
        isPlaying = false;
    }
    /// <summary>
    /// ������Ƶ��ͣ����
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
