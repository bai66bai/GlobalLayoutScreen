using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMonitorTcpMsgHandler : TCPMsgHandler
{
    public CtrLoadScene CtrLoadScene;
    public CtrBtnsEM CtrBtnsEM;
    public float OverdueTime = 3f;
    public CtrlScreenCastShow ctrlScreenCastShow;
    public List<CtrlScreenVideoPlayer> ctrlScreenVideoPlayers;
    private CtrlScreenVideoPlayer ctrlScreenVideoPlayer;
    private string keyName = "";

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
                Debug.Log(swipeDetection);
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
            case "play":
                string[] Content = param.Split('-');
                if (keyName == "")
                {                
                    keyName = Content[1];
                    ctrlScreenCastShow.StartScreen(Content[0]);
                                ctrlScreenVideoPlayers.ForEach(item =>
                                {
                                    if (item.gameObject.activeSelf)
                                    {
                                        ctrlScreenVideoPlayer = item;
                                    }
                                });
                }  
                break;
            case "ScreenCast":
                string[] Contents = param.Split('-');
                if (keyName == Contents[1])
                {
                    ctrlScreenVideoPlayer?.ToggleScreenPlayPause();
                }
                
                break;
            case "close":
                string[] Close = param.Split('-');
                if(keyName == Close[1])
                {
                    ctrlScreenCastShow.EndScreenCast();
                    keyName = "";
                }
                break;
        }
    }
}
