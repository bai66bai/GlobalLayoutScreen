using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyTcpMsgHandler : TCPMsgHandler
{
    public CtrVideoPlayer CtrVideoPlayer;
    public LevelLoader LevelLoader;
    public override void HandleMsg(string msg)
    {
        var splitedMsg = msg.Split(':');
        var operation = splitedMsg[0];
        var param = splitedMsg[1];
        switch (operation)
        {
            case "touchScreen":
                CtrVideoPlayer.TogglePlayPause();
                break;
            case "stopVideo":
                CtrVideoPlayer.CtrlStopVideo();
                break;
        }
    }
}
