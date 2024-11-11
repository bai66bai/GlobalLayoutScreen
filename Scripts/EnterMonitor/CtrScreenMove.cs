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
        // �ݴ� obj1 �� Transform ����
        Vector3 tempPosition = obj1.position;
        Quaternion tempRotation = obj1.rotation;
        Vector3 tempScale = obj1.localScale;

        // ����λ�á���ת������
        obj1.position = obj2.position;
        obj1.rotation = obj2.rotation;
        obj1.localScale = obj2.localScale;

        obj2.position = tempPosition;
        obj2.rotation = tempRotation;
        obj2.localScale = tempScale;

        RectTransform rect1 = obj1.GetComponent<RectTransform>();
        RectTransform rect2 = obj2.GetComponent<RectTransform>();
        // �ݴ� rect1 �� sizeDelta
        (rect2.sizeDelta, rect1.sizeDelta) = (rect1.sizeDelta, rect2.sizeDelta);
    }

    void SwapHierarchy(Transform obj1, Transform obj2)
    {
        // �ݴ游����
        Transform tempParent1 = obj1.parent;
        Transform tempParent2 = obj2.parent;

        // �ݴ�λ������
        int siblingIndex1 = obj1.GetSiblingIndex();
        int siblingIndex2 = obj2.GetSiblingIndex();

        // ����������
        obj1.SetParent(tempParent2);
        obj2.SetParent(tempParent1);

        // �����ڸ������е�˳��
        obj1.SetSiblingIndex(siblingIndex2);
        obj2.SetSiblingIndex(siblingIndex1);
    }

}
