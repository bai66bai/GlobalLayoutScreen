using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeDetection : MonoBehaviour
{
    public RectTransform swipeArea;
    public float duration = 0.5f;
    public int MovingDistance = 1920;

    public Turnthepage Turnthepage;

    public List<MonitorVlcCtrl> MonitorVlcCtrls;

    private MonitorVlcCtrl currentVlcCtrl;

    private bool isFinish = true;
    [HideInInspector] public int bigIndex; //最大滑动次数

    [HideInInspector] public int nowIndex;

    void Start()
    {
        float width = swipeArea.rect.width;
        bigIndex = (int)width / MovingDistance;
    }


    public void ToRight()
    {
        if (nowIndex > 0 && isFinish)
        {
            Vector3 localPostion = transform.localPosition;
            Vector3 targetLocalPosition = new Vector3(localPostion.x + MovingDistance, localPostion.y, localPostion.z);
            StartCoroutine(MoveAndScaleOverTime(targetLocalPosition, duration));
            --nowIndex;
            Turnthepage.ChangeBtnColor(nowIndex);
            isFinish = false;
            CtrlVideoPauseAndPlay();
        }
    }


    public void ToLeft()
    {
        if (nowIndex < bigIndex - 1 && isFinish)
        {
            Vector3 localPostion = transform.localPosition;
            Vector3 targetLocalPosition = new Vector3(localPostion.x - MovingDistance, localPostion.y, localPostion.z);
            StartCoroutine(MoveAndScaleOverTime(targetLocalPosition, duration));
            ++nowIndex;
            Turnthepage.ChangeBtnColor(nowIndex);
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
                vLCPlayerExample.Pause();
            }
        }

        foreach (var monitorVlcCtrl in MonitorVlcCtrls)
        {
            if(nowIndex == monitorVlcCtrl.index)
            {
                currentVlcCtrl = monitorVlcCtrl;
                foreach (var vLCPlayerExample in currentVlcCtrl.vLCPlayerExamples)
                {
                    vLCPlayerExample.Resume();
                }
                break;
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