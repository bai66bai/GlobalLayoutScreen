using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CtrScreenMove : MonoBehaviour
{
    public List<GameObject> Screens;

    public float duration = 2.0f;

    public int VId;

    private Vector3 targetPosition;

    private Vector3 targetLocalScale;

    private bool isInOver = true;
    private bool isOutOver = true;

    private Vector3 centerPosition = new(0f, 0f, 0f);

    private int selectedIndex;

    private Vector3 centerLocalScale = new(2.1f, 2.1f, 0f);


    public void OnClickScreen(string name)
    {
        if (isInOver && isOutOver)
        {
            Screens.ForEach(t =>
            {
                if (t.name == name)
                {
                    selectedIndex = t.GetComponent<ScreenIndex>().Index;
                    targetPosition = t.transform.localPosition;
                    targetLocalScale = t.transform.localScale;
                    isInOver = false;
                    StartCoroutine(ChangeScreen(t.transform, centerPosition, centerLocalScale, duration, true));
                    FindCenterScreen();
                    t.GetComponent<ScreenIndex>().Index = 0;
                }

            });
        }

    }


    public void FindCenterScreen()
    {
        Screens.ForEach(t =>
        {
            int centerIndex = t.GetComponent<ScreenIndex>().Index;
            if (centerIndex == 0)
            {
                isOutOver = false;
                StartCoroutine(ChangeScreen(t.transform, targetPosition, targetLocalScale, duration, false));
                t.GetComponent<ScreenIndex>().Index = selectedIndex;
            }

        });
    }

    IEnumerator ChangeScreen(Transform screen, Vector3 pos, Vector3 scale, float duration, bool isIn)
    {
        Vector3 initialPosition = screen.localPosition;
        Vector3 initialScale = screen.localScale;
        float startTime = 0f;
        while (startTime < duration)
        {
            float t = startTime / duration;
            float nextX = Mathf.SmoothStep(initialPosition.x, pos.x, t);
            float nextY = Mathf.SmoothStep(initialPosition.y, pos.y, t);
            float nextZ = Mathf.SmoothStep(initialPosition.z, pos.z, t);
            float scaleX = Mathf.SmoothStep(initialScale.x, scale.x, t);
            float scaleY = Mathf.SmoothStep(initialScale.y, scale.y, t);
            float scaleZ = Mathf.SmoothStep(initialScale.z, scale.z, t);
            screen.localPosition = new Vector3(nextX, nextY, nextZ);
            screen.localScale = new Vector3(scaleX, scaleY, scaleZ);
            startTime += Time.deltaTime;
            yield return null;
        }
        screen.localPosition = pos;
        screen.localScale = scale;
        if (isIn) isInOver = true;
        else isOutOver = true;
    }
}
