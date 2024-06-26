using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CtrVideoPrefab : MonoBehaviour
{
    public GameObject Prefab;

    public Transform parentTransform; // ָ��������
    public Vector3 localPosition = new Vector3(0,0,0); // �ڸ�����ı��������е�λ��

    public void LoadPrefabSync() => StartCoroutine(LoadPrefab());

    IEnumerator LoadPrefab()
    {
        GameObject instance = Instantiate(Prefab, parentTransform);
        instance.transform.localPosition = localPosition;
        yield return null;
    }
}
