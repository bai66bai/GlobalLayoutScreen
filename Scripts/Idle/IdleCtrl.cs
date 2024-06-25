using UnityEngine;
using UnityEngine.Video;

public class IdleCtrl : MonoBehaviour
{
    public VideoClip IdleVideo;  // ����������������Inspector��������Ƶ����
    public float IdleTime = 900f;

    private static GameObject VideoObj;
    private VideoPlayer videoPlayer;  // ��Ƶ���������������
    private static float baseTime = 0f;


    void Start()
    {
        // ��ȡ���GameObject�����Ӷ����ϵ�VideoPlayer���
        VideoObj = transform.GetChild(0).gameObject;
        videoPlayer = VideoObj.GetComponent<VideoPlayer>();

        // ����Ƿ�ɹ���ȡVideoPlayer���
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer component not found on the GameObject");
            return;
        }

        // ����VideoPlayer����Ƶ����
        videoPlayer.clip = IdleVideo;

        
        VideoObj.SetActive(false);
    }


    void Update()
    {
        if(Time.time - baseTime > IdleTime && !VideoObj.activeSelf)
        {
            VideoObj.SetActive(true);
        }
    }

    /// <summary>
    /// ��̬��������ϵ�ǰ������Ƶ
    /// </summary>
    public static void BreakIdle()
    {
        baseTime = Time.time;
        VideoObj?.SetActive(false);
    }

}
