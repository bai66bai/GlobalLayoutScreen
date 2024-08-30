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
    private string keyName = "";
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
                string[] Content = param.Split("-");
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
                    ctrlScreenVideoPlayer.GetComponent<CtrlVideoMutePlay>().StartMute();
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
                if (keyName == Close[1])
                {
                    ctrlScreenCastShow.EndScreenCast();
                    keyName = "";
                    ctrlScreenVideoPlayer.GetComponent<CtrlVideoMutePlay>().EndMute();
                }
                break;
        }
    }
}
