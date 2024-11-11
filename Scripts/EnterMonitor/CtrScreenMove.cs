using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CtrScreenMove : MonoBehaviour
{
    public List<GameObject> Screens;

    public int VId;


    public void OnClickScreen(string name)
    {
        Screens.ForEach(t =>
        {
            if (t.name == name)
            {
                SwapTransforms(transform.GetChild(0).transform, t.transform);
                SwapHierarchy(transform.GetChild(0).transform, t.transform);
                return;
            }
        });
    }

    void SwapTransforms(Transform obj1, Transform obj2)
    {
        // 暂存 obj1 的 Transform 属性
        Vector3 tempPosition = obj1.position;
        Quaternion tempRotation = obj1.rotation;
        Vector3 tempScale = obj1.localScale;

        // 交换位置、旋转和缩放
        obj1.position = obj2.position;
        obj1.rotation = obj2.rotation;
        obj1.localScale = obj2.localScale;

        obj2.position = tempPosition;
        obj2.rotation = tempRotation;
        obj2.localScale = tempScale;

        RectTransform rect1 = obj1.GetComponent<RectTransform>();
        RectTransform rect2 = obj2.GetComponent<RectTransform>();
        // 暂存 rect1 的 sizeDelta
        (rect2.sizeDelta, rect1.sizeDelta) = (rect1.sizeDelta, rect2.sizeDelta);
    }

    void SwapHierarchy(Transform obj1, Transform obj2)
    {
        // 暂存父对象
        Transform tempParent1 = obj1.parent;
        Transform tempParent2 = obj2.parent;

        // 暂存位置索引
        int siblingIndex1 = obj1.GetSiblingIndex();
        int siblingIndex2 = obj2.GetSiblingIndex();

        // 交换父对象
        obj1.SetParent(tempParent2);
        obj2.SetParent(tempParent1);

        // 交换在父对象中的顺序
        obj1.SetSiblingIndex(siblingIndex2);
        obj2.SetSiblingIndex(siblingIndex1);
    }

}
