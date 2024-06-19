using System.Collections;
using UnityEngine;

public class CtrImgScale : MonoBehaviour
{


    private bool isZoomed = false;  

    public float duration = 0.5f;

    private Vector2 targetSize = new(1066f, 600f);

    private Vector2 targetPosition;

    private RectTransform rectTransform;

    private Canvas canvas;

    private Vector2 originalPosition; //��ʼλ��

    private Vector2 originalSize; //��ʼ�ߴ�

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // ��ȡ��ǰ����Ŀ�Ⱥ͸߶�
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;
        originalSize = new Vector2(width, height);
       
        // ��ȡCanvas
        canvas = GetComponentInParent<Canvas>();
        targetPosition = canvas.transform.position;
    }

    public void OnClick()
    {
        if (isZoomed)
        {
            StartCoroutine(AnimateZoom(originalPosition, originalSize));
        }
        else
        {
            originalPosition = rectTransform.position; //�����ʼλ��
            StartCoroutine(AnimateZoom(targetPosition, targetSize));
        }

        // �л�״̬
        isZoomed = !isZoomed;
    }

    public void Scale(string target) => StartCoroutine(AnimateZoom(target == "big" ? targetPosition : originalPosition, target == "big" ? targetSize : originalSize));

    private IEnumerator AnimateZoom( Vector2 targetPosition, Vector2 targetSize)
    {
      
        Vector2 startPosition = rectTransform.position;
        Vector2 startSize = rectTransform.sizeDelta;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;  
            rectTransform.position = Vector2.Lerp(startPosition, targetPosition, t);
            rectTransform.sizeDelta = Vector2.Lerp(startSize, targetSize, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // ȷ������ֵ
        rectTransform.position = targetPosition;
        rectTransform.sizeDelta = targetSize;
    }

}
