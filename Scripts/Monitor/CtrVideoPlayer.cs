
using UnityEngine;
using UnityEngine.Video;

public class CtrVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer; // ��Ƶ���������
    private bool isPlaying = false; // ��ǰ����״̬

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
        // ȷ����Ƶһ��ʼ�ǲ��ŵĵ�
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
