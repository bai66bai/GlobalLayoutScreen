using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrScale : MonoBehaviour
{
    // ���ŷ�Χ
    public float minScale = 1.0f;
    public float maxScale = 1.25f;
    public float delaySeconds = 1.0f;

    // �����ٶ�
    public float scaleSpeed = 1.0f;

    private RectTransform rectTransform;

    void Start()
    {
        // ��ȡ RectTransform ���
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Time.time < delaySeconds) return;
        // ��������ֵ
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong((Time.time - delaySeconds) * scaleSpeed, 1.0f));

        // ��������
        rectTransform.localScale = new Vector3(scale, scale, 1.0f);
    }
}
