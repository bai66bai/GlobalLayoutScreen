using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class StreamVideoPlayer : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public string VideoName;

    private void Start()
    {
        if(VideoPlayer != null)
        {
            Debug.Log(VideoName);
            VideoFile(VideoName, null , VideoPlayer);
        }
    }

    public void VideoFile(string videoName , VLCPlayerExample vLCPlayerExample , VideoPlayer videoPlayer)
    {
        StartCoroutine(ReadFile(videoName, vLCPlayerExample , videoPlayer));
    }


    IEnumerator ReadFile(string videoName, VLCPlayerExample vLCPlayerExample, VideoPlayer videoPlayer)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, videoName);

        UnityWebRequest www = UnityWebRequest.Get(filePath);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            if (vLCPlayerExample != null)
            {
                vLCPlayerExample.path = filePath;
                 Debug.Log(0);
                // ����VideoPlayer����Ƶ����
                 vLCPlayerExample.StartVideoWithUrlAsync(filePath);
            }else if(videoPlayer != null)
            {
                videoPlayer.url = filePath;
                videoPlayer.Prepare();  
            }
            
        }
        else
        {
            Debug.LogError("����ʧ�ܣ� " + www.error);
        }
    }
    private void OnDestroy()
    {
        VideoPlayer?.targetTexture?.Release();
    }
}
