using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisableCtrl : MonoBehaviour
{
    public GameObject text;

    public void TextDisable()
    {
        text.SetActive(false);
    }
}
