using UnityEngine;
using UnityEngine.Video;

public class IdleCtrl : MonoBehaviour
{
    public VideoClip IdleVideo;  // 公共变量，用于在Inspector中设置视频剪辑
    public float IdleTime = 900f;

    private static GameObject VideoObj;
    private VideoPlayer videoPlayer;  // 视频播放器组件的引用
    private static float baseTime = 0f;


    void Start()
    {
        // 获取这个GameObject或其子对象上的VideoPlayer组件
        VideoObj = transform.GetChild(0).gameObject;
        videoPlayer = VideoObj.GetComponent<VideoPlayer>();

        // 检查是否成功获取VideoPlayer组件
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer component not found on the GameObject");
            return;
        }

        // 设置VideoPlayer的视频剪辑
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
    /// 静态方法：打断当前待机视频
    /// </summary>
    public static void BreakIdle()
    {
        baseTime = Time.time;
        VideoObj?.SetActive(false);
    }

}
