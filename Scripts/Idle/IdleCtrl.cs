using LibVLCSharp;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class IdleCtrl : MonoBehaviour
{
    //public VideoClip IdleVideo;  // ����������������Inspector��������Ƶ����
    public float IdleTime = 900f;
    public StreamVideoPlayer StreamVideoPlayer;
    public GameObject VlcPrefab;
    private static GameObject VideoObj;
    private VLCPlayerExample vLCPlayerExample;  // ��Ƶ���������������
    private static float baseTime = 0f;
    private static bool shouldDestory = false;
    private string IdleVideourl;

    private bool isStop = false;

    void Start()
    {
        InitVideo();
    }


    private void InitVideo()
    {
        VideoObj = Instantiate(VlcPrefab, transform);
        VideoObj.transform.localPosition = Vector3.zero;
        VideoObj.SetActive(false);
        // ����Ƿ�ɹ���ȡVideoPlayer���
        if (!VideoObj.TryGetComponent(out vLCPlayerExample))
        {
            Debug.LogError("VideoPlayer component not found on the GameObject");
            return;
        }
    }


    void Update()
    {

        if (VideoObj != null && !VideoObj.activeSelf
            && Time.time - baseTime > IdleTime)
        {
            // ��һ�β���
            VideoObj.SetActive(true);
            //StartCoroutine(ReadFile());
            StreamVideoPlayer.VideoFile("global.mp4", vLCPlayerExample,null);
        } else if(VideoObj == null && SceneManager.GetActiveScene().name != "IdleScene")
        {
            InitVideo();
        }

        if (vLCPlayerExample != null
            && vLCPlayerExample.mediaPlayer != null)
        {

            if (vLCPlayerExample.mediaPlayer.State == VLCState.Stopping && !isStop)
            {
                isStop = true;
                vLCPlayerExample.Play();
            }
            else
            {
                isStop = false;
            }
        }

        if (shouldDestory)
        {
            vLCPlayerExample.DestroyMediaPlayer();
            Destroy(VideoObj);
            shouldDestory = false;
        }
    }

    /// <summary>
    /// ��̬��������ϵ�ǰ������Ƶ
    /// </summary>
    public static void BreakIdle()
    {
        baseTime = Time.time;
        shouldDestory = true;
    }


    IEnumerator ReadFile()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "a.mp4");

        UnityWebRequest www = UnityWebRequest.Get(filePath);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            IdleVideourl = filePath;
            vLCPlayerExample.path = filePath;
            Debug.Log(0);
            // ����VideoPlayer����Ƶ����
            vLCPlayerExample.StartVideoWithUrlAsync(IdleVideourl);
        }
        else
        {
            Debug.LogError("����ʧ�ܣ� " + www.error);
        }
    }
}
