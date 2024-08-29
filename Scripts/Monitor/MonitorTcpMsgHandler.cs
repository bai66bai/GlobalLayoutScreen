using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorTcpMsgHandler : TCPMsgHandler
{

    public CtrVideoPlayer CtrVideoPlayer;
    public LevelLoader LevelLoader;
    public CtrlScreenCastShow ctrlScreenCastShow;
    public List<CtrlScreenVideoPlayer> ctrlScreenVideoPlayers;
    private CtrlScreenVideoPlayer ctrlScreenVideoPlayer;
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
            case "cityIndex":
                TabStore.SelectedTab = int.Parse(param);
                LevelLoader.LoadNewScene("EnterMonitorScene");
                break;
            case "play":
                ctrlScreenCastShow.StartScreen(param);
                ctrlScreenVideoPlayers.ForEach(item =>
                {
                    if (item.gameObject.activeSelf)
                    {
                        ctrlScreenVideoPlayer = item;
                    }
                });
                break;
            case "ScreenCast":
                ctrlScreenVideoPlayer?.ToggleScreenPlayPause();
                break;
            case "close":
                ctrlScreenCastShow.EndScreenCast();
                break;
        }
    }
}
