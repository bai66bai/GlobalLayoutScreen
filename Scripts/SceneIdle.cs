using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIdle : MonoBehaviour
{
    public static bool ShouldReset = false;
    public float timeoutSeconds = 5; // 用户无操作的超时时间（秒）
    private float lastInteractionTime; // 记录最后操作时间

    void Start()
    {
        SceneManager.LoadSceneAsync("IdleScene", LoadSceneMode.Additive);
        ResetTimer();
    }

    void Update()
    {
        // 检查是否有网络请求
        if (ShouldReset)
        {
            ResetTimer();
            ShouldReset = false;
        }

        // 检查是否超时
        if (Time.time - lastInteractionTime > timeoutSeconds)
        {
            // 激活待机场景根对象
            Scene targetScene = SceneManager.GetSceneByName("IdleScene");
            if (targetScene.isLoaded)
            {
                GameObject[] rootObjects = targetScene.GetRootGameObjects();
                foreach (GameObject obj in rootObjects)
                {
                    if(obj.name =="MainObj")
                        obj.SetActive(true);
                }
            }

            // 隐藏当前场景根对象
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.isLoaded)
            {
                GameObject[] rootObjects = currentScene.GetRootGameObjects();
                foreach (GameObject obj in rootObjects)
                {
                    if (obj.name == "MainObj")
                        obj.SetActive(false);
                }
            }

        }
    }

    private void OnEnable()
    {
        ResetTimer();
    }

    // 重置计时器
    public void ResetTimer()
    {
        lastInteractionTime = Time.time;
    }

}
