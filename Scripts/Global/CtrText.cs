using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrText : MonoBehaviour
{
    private Quaternion initialRotation;
    private Transform parentTransform;

    void Start()
    {
        // ��¼���ֶ���ĳ�ʼ��ת
        initialRotation = transform.rotation;
        // ��ȡ�������Transform
        parentTransform = transform.parent;
    }

    void LateUpdate()
    {
        // �������ֶ������ת�������������ϵ����
        transform.rotation = initialRotation;
    }
}
