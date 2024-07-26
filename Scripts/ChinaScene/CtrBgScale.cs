using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CtrBgScale : MonoBehaviour
{

    public Vector3 targetLocalPosition = new(-765f, 430f, 0);
    public Vector3 targetScale = new(1.8f, 1.8f, 1f);


    //��¼��ʼ�����Լ�λ��
    private Vector3 initialPosition;
    private Vector3 initialScale;

    public static bool ScaleExpand = false;
    public float duration = 2.0f;
    public static bool ScaleFinish = true;
    private void Start()
    {
        initialPosition = transform.localPosition;
        initialScale = transform.localScale;
    }

    public void ClickBtnSCale()
    {
        ScaleFinish = false;
        StartCoroutine(MoveAndScaleOverTime(targetLocalPosition, targetScale, duration, true));
    }


    public void ClickBtnSCaleEnd()
    {
        ScaleFinish = false;
        StartCoroutine(MoveAndScaleOverTime(initialPosition, initialScale, duration, false));
    }
    private IEnumerator MoveAndScaleOverTime(Vector3 newLocalPosition, Vector3 newScale, float time, bool IsScale)
    {
        Vector3 initPos = transform.localPosition;
        Vector3 initScale = transform.localScale;

        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;

            float targetPostionX = Mathf.SmoothStep(initPos.x, newLocalPosition.x, t);
            float targetPostionY = Mathf.SmoothStep(initPos.y, newLocalPosition.y, t);
            transform.localPosition = new Vector3(targetPostionX, targetPostionY, 0);
            float targetScaleX = Mathf.SmoothStep(initScale.x, newScale.x, t);
            float targetScaleY = Mathf.SmoothStep(initScale.y, newScale.y, t);
            transform.localScale = new Vector3(targetScaleX, targetScaleY, 1f);
            elapsedTime += Time.smoothDeltaTime;
            yield return null;
        }
        transform.localPosition = newLocalPosition;
        transform.localScale = newScale;
        ScaleExpand = IsScale;
        ScaleFinish = true;
    }
}