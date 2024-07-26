using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrPopupWiindow : MonoBehaviour
{
    private Vector3 targetLocalPosition = new(0, 0, 0);

    //¼ÇÂ¼³õÊ¼Î»ÖÃ
    private Vector3 initialPosition;
    public float duration = 2.0f;

    public static bool IsFinish = false;
    public List<GameObject> DetailList;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (!IsFinish)
        {
            DetailList.ForEach(e =>
            {
                if (e.activeSelf && e.GetComponent<CtrContentActive>().IsMoveEnd)
                {
                    IsFinish = true;
                    return;
                }
            });
        }

    }

    public void StartMove()
    {
        StartCoroutine(MoveAndScaleOverTime(targetLocalPosition, duration , true));
    }

    public void StartMoveEnd()
    {
        StartCoroutine(MoveAndScaleOverTime(initialPosition, duration , false));
    }

    public void AllShow()
    {
        DetailList.ForEach((e) =>
        {
            e.SetActive(true);
        });
    }

    private IEnumerator MoveAndScaleOverTime(Vector3 newLocalPosition, float time, bool IsPopu)
    {
        Vector3 initPos = transform.localPosition;

        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;

            float targetPostionX = Mathf.SmoothStep(initPos.x, newLocalPosition.x, t);
            transform.localPosition = new Vector3(targetPostionX, 0, 0);

            elapsedTime += Time.smoothDeltaTime;
            yield return null;
        }
        transform.localPosition = newLocalPosition;
        if (!IsPopu)
            AllShow();
    }
}
