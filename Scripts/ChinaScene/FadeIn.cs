using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour
{
    public Image image; // ��Ҫ����͸���ȵ�ͼƬ
    public List<TextMeshProUGUI> texts;
    public float duration = 0.5f; // ����ʱ��

    void Start()
    {
        // ��ʼ����Э��
        StartCoroutine(FadeInImage());
        foreach (TextMeshProUGUI text in texts)
        {
            StartCoroutine(FadeInText(text, duration));
        }
    }

    IEnumerator FadeInImage()
    {
        Color color = image.color;
        color.a = 0;
        image.color = color;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration); // ����alphaֵ
            color.a = alpha;
            image.color = color;
            yield return null;
        }

        // ȷ������alphaΪ1��255��
        color.a = 1f;
        image.color = color;
    }


    IEnumerator FadeInText(TextMeshProUGUI text, float duration)
    {
        // ��ʼ��ɫ��ȷ��alphaΪ0
        Color color = text.color;
        color.a = 0;
        text.color = color;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration); // ����alphaֵ
            color.a = alpha; // �����µ�alphaֵ
            text.color = color; // Ӧ�õ�������
            yield return null; // �ȴ���һ֡
        }

        // ȷ������alphaΪ1��255��
        color.a = 1f;
        text.color = color;
    }
}
