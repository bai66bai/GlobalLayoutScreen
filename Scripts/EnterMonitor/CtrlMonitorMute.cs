using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlMonitorMute : MonoBehaviour
{
    private VLCPlayerExample vlcPlayerExample;

    void OnEnable()
    {
        vlcPlayerExample = gameObject.GetComponent<VLCPlayerExample>();
        // 启动协程等待初始化完成
        StartCoroutine(WaitForInitialization());
    }

    IEnumerator WaitForInitialization()
    {
        // 等待直到 vlcPlayerExample 和 mediaPlayer 都初始化完成
        while (vlcPlayerExample == null || vlcPlayerExample.mediaPlayer == null)
        {
            yield return null; // 每帧等待一次
        }
        // 这里可以添加对 mediaPlayer 的操作，比如静音
        vlcPlayerExample.mediaPlayer.Mute = true;
    }
}
