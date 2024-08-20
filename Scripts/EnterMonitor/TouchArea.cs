using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchArea : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool isSwiping = false;
    public SwipeDetection swipeDetection;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPoint = eventData.position;
        isSwiping = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ������Ը�����Ҫ����϶���������ʾ�϶��켣�Ĵ���
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        endPoint = eventData.position;
        isSwiping = false;
        DetectSwipeDirection();
    }

    private void DetectSwipeDirection()
    {
        if (isSwiping)
        {
            return;
        }
        
        float deltaX = endPoint.x - startPoint.x;
        if (Mathf.Abs(deltaX) > 50)  // ����һ����ֵ������΢С�Ļ���Ҳ����⵽
        {
            if (deltaX > 0)
            {
                swipeDetection.ToRight();
            }
            else
            {
                swipeDetection.ToLeft();
            }
        }
    }
}
