using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlMonitorMute : MonoBehaviour
{
    private VLCPlayerExample vlcPlayerExample;

    void OnEnable()
    {
        vlcPlayerExample = gameObject.GetComponent<VLCPlayerExample>();
        // ����Э�̵ȴ���ʼ�����
        StartCoroutine(WaitForInitialization());
    }

    IEnumerator WaitForInitialization()
    {
        // �ȴ�ֱ�� vlcPlayerExample �� mediaPlayer ����ʼ�����
        while (vlcPlayerExample == null || vlcPlayerExample.mediaPlayer == null)
        {
            yield return null; // ÿ֡�ȴ�һ��
        }
        // ���������Ӷ� mediaPlayer �Ĳ��������羲��
        vlcPlayerExample.mediaPlayer.Mute = true;
    }
}
