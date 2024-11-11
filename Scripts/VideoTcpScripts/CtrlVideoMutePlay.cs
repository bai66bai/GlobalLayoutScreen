using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CtrlVideoMutePlay : MonoBehaviour
{
   
    public VideoPlayer player;

    public void StartMute()
    {
        Debug.Log("¿ªÊ¼¾²Òô");
        player.SetDirectAudioMute(0,true);
    }

    public void EndMute()
    {
             Debug.Log("½áÊø¾²Òô");
        player.SetDirectAudioMute(0, false);
    }
}
