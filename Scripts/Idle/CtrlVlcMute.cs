using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlVlcMute : MonoBehaviour
{
    public VLCPlayerExample vlcPlayerExample;

    void OnEnable()
    {
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
        vlcPlayerExample.mediaPlayer.SetVolume(0);
    }
}
