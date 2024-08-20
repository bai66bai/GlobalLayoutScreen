using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibVLCSharp;

public class TestVlc : MonoBehaviour
{
    private VLCPlayerExample vLCPlayerExample;

    private int count = 0;
    private bool isPlay = false;
    private bool isPause = false;
    private bool isSecondPlay = false;
    void Start()
    {
        vLCPlayerExample = GetComponent<VLCPlayerExample>();
    }

    void Update()
    {
        count++;
        if(count > 2500 && !isPlay)
        {
            vLCPlayerExample.Play();
            isPlay = true;
            Debug.Log(1);
        }

        if(count > 5000 && !isPause)
        {
            vLCPlayerExample.Pause();
            isPause = true;
            Debug.Log(2);
        }

        if(count > 7500 && !isSecondPlay)
        {
            vLCPlayerExample.Resume();
            isSecondPlay = true;
            Debug.Log(3);
        }
    }
}
