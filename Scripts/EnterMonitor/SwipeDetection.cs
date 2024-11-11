using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeDetection : MonoBehaviour
{
    public RectTransform swipeArea;
    public float duration = 0.5f;
    public int MovingDistance = 1920;

    public List<MonitorVlcCtrl> MonitorVlcCtrls;

    private MonitorVlcCtrl currentVlcCtrl;

    private bool isFinish = true;
    [HideInInspector] public int bigIndex; //最大滑动次数

    [HideInInspector] public int nowIndex;

    void Start()
    {
        float width = swipeArea.rect.width;
        bigIndex = (int)width / MovingDistance;
        currentVlcCtrl = MonitorVlcCtrls[0];
    }


    public void ToRight()
    {
        Debug.Log($"nowIndex: {nowIndex}");

        Debug.Log(isFinish);

        if (nowIndex > 0 && isFinish)
        {
            Vector3 localPostion = transform.localPosition;
            Vector3 targetLocalPosition = new(localPostion.x + MovingDistance, localPostion.y, localPostion.z);
            StartCoroutine(MoveAndScaleOverTime(targetLocalPosition, duration));
            --nowIndex;
            isFinish = false;
            CtrlVideoPauseAndPlay();
        }
    }


    public void ToLeft()
    {
        Debug.Log($"nowIndex: {nowIndex}");
        Debug.Log($"bigIndex-1: {bigIndex-1}");
        Debug.Log(isFinish);
        if (nowIndex < bigIndex - 1 && isFinish)
        {
            Debug.Log(0);

            Vector3 localPostion = transform.localPosition;
            Vector3 targetLocalPosition = new Vector3(localPostion.x - MovingDistance, localPostion.y, localPostion.z);
            StartCoroutine(MoveAndScaleOverTime(targetLocalPosition, duration));
            ++nowIndex;
            isFinish = false;
            CtrlVideoPauseAndPlay();
        }
    }

    private void CtrlVideoPauseAndPlay()
    {
        if(currentVlcCtrl != null)
        {
            foreach (var vLCPlayerExample in currentVlcCtrl.vLCPlayerExamples)
            {
                vLCPlayerExample.Stop();
            }
        }

        foreach (var monitorVlcCtrl in MonitorVlcCtrls)
        {
            try
            {
                if (nowIndex == monitorVlcCtrl.index)
                {
                    currentVlcCtrl = monitorVlcCtrl;
                    foreach (var vLCPlayerExample in currentVlcCtrl.vLCPlayerExamples)
                    {
                        vLCPlayerExample.Play();
                    }
                    break;
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
            }
           
        }
    }

    private IEnumerator MoveAndScaleOverTime(Vector3 newLocalPosition, float time)
    {
        Vector3 initialPosition = transform.localPosition;

        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;

            float targetPostionX = Mathf.SmoothStep(initialPosition.x, newLocalPosition.x, t);
            transform.localPosition = new Vector3(targetPostionX, newLocalPosition.y, newLocalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = newLocalPosition;
        isFinish = true;
    }

}