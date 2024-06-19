using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrRotation : MonoBehaviour
{
    // ��ת�ٶȣ���/�룩
    public float rotationSpeed = 45.0f;

    // ������������
    public bool rotateClockwise = true;

    void Update()
    {
        // ���� rotateClockwise ������ת����
        float direction = rotateClockwise ? 1 : -1;

        // ÿ֡��Z����ת
        transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
    }
}
