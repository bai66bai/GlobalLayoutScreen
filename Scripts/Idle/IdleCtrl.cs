using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class IdleCtrl : MonoBehaviour
{
    //public VideoClip IdleVideo;  // ����������������Inspector��������Ƶ����
    public float IdleTime = 900f;

    public GameObject VlcPrefab;
    private static GameObject VideoObj;
    private VLCPlayerExample vLCPlayerExample;  // ��Ƶ���������������
    private static float baseTime = 0f;
    private static bool shouldDestory = false;
    private string IdleVideourl;

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
            StartCoroutine(ReadFile());
        } else if(VideoObj == null && SceneManager.GetActiveScene().name != "IdleScene")
        {
            InitVideo();
        }

        if (vLCPlayerExample != null
            && vLCPlayerExample.mediaPlayer != null
            && vLCPlayerExample.mediaPlayer.Time > vLCPlayerExample.mediaPlayer.Length - 1)
        {
            vLCPlayerExample.mediaPlayer.SetTime(0);
        }

        if(shouldDestory)
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
            // ����VideoPlayer����Ƶ����
            vLCPlayerExample.StartVideoWithUrlAsync(IdleVideourl);
        }
        else
        {
            Debug.LogError("����ʧ�ܣ� " + www.error);
        }
    }
}
