using System.Collections;
using UnityEngine;

public class CtrImgScale : MonoBehaviour
{


    public bool isZoomed = false;  

    public float duration = 0.5f;

    public Vector2 targetSize = new(2200f, 930f);

    public Vector2 targetPosition = new(2200f, 930f);

    private RectTransform rectTransform;

    //private Canvas canvas;

    private Vector2 originalPosition; //初始位置

    private Vector2 originalSize; //初始尺寸
    private bool isCoroutineRunning = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // 获取当前对象的宽度和高度
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;
        originalSize = new Vector2(width, height);
       
        // 获取Canvas
        //canvas = GetComponentInParent<Canvas>();
        //targetPosition = canvas.transform.position;
    }

    public void OnClick()
    {
        if (!isCoroutineRunning)
        {
            isCoroutineRunning = true;
         if (isZoomed)
                {
                    StartCoroutine(AnimateZoom(originalPosition, originalSize));
                }
                else
                {
                    originalPosition = rectTransform.localPosition; //保存初始位置
                    StartCoroutine(AnimateZoom(targetPosition, targetSize));
                }

                // 切换状态
                isZoomed = !isZoomed;
        }
       
    }

    public void Scale(string target) => StartCoroutine(AnimateZoom(target == "big" ? targetPosition : originalPosition, target == "big" ? targetSize : originalSize));

    private IEnumerator AnimateZoom( Vector2 targetPosition, Vector2 targetSize)
    {
      
        Vector2 startPosition = rectTransform.localPosition;
        Vector2 startSize = rectTransform.sizeDelta;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;  
            rectTransform.localPosition= Vector2.Lerp(startPosition, targetPosition, t);
            rectTransform.sizeDelta = Vector2.Lerp(startSize, targetSize, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // 确保最终值
        rectTransform.localPosition = targetPosition;
        rectTransform.sizeDelta = targetSize;
        isCoroutineRunning = false;
    }

}
