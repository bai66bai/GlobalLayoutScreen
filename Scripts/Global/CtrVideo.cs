using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CtrVideo : MonoBehaviour
{
    public RenderTexture RenderTexture;
    public VideoPlayer videoPlayer;
    public string nextSceneName;
    public GameObject GameObject;

    void Start()
    {
        RenderTexture.Release();

        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // ע��loopPointReached�¼��ļ�����
        videoPlayer.loopPointReached += OnVideoFinished;

    }

      public void OnLodeScene()
        {
        GameObject.SetActive(true);
    }
    void OnVideoFinished(VideoPlayer vp)
    {
        // �л�����һ������
        SceneManager.LoadScene(nextSceneName);  
    }

    private void OnDisable()
    {
        RenderTexture.Release();
    }
}
