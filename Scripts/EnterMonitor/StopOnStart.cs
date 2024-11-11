using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnStart : MonoBehaviour
{
    void Start()
    {
        var vlcs = GetComponentsInChildren<VLCPlayerExample>();
        foreach (var vlc in vlcs)
        {
            vlc.Stop();
        }
    }
}
