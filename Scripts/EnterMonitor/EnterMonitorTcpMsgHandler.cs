using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMonitorTcpMsgHandler : TCPMsgHandler
{
    public CtrLoadScene CtrLoadScene;
    public CtrBtnsEM CtrBtnsEM;
    public float OverdueTime = 3f;

    public override void HandleMsg(string msg)
    {
        var splitedMsg = msg.Split(':');
        var operation = splitedMsg[0];
        var param = splitedMsg[1];
        switch (operation)
        {
            case "btnName":
                 CtrBtnsEM.OnClickBtn(param);
                break;
            case "scroll":
                SwipeDetection swipeDetection = FindObjectOfType<SwipeDetection>();
                (param == "left" ? new Action(swipeDetection.ToLeft) : new Action(swipeDetection.ToRight))();
                break;
            case "sceneName":
                if (param != "MenuScene")
                  CtrLoadScene.StartDestroy(param);
                break;
            case "screenName":
                var videos = param.Split("-");
                CtrScreenMove[] ctrScreens = FindObjectsByType<CtrScreenMove>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
                foreach (var ctrScreen in ctrScreens)
                {
                    if (ctrScreen.VId.ToString() == videos[0]) ctrScreen.OnClickScreen(videos[1]);
                }
                break;
        }
    }
}
