
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GlobalTcpMsgHandler : TCPMsgHandler
{
    public CtrBtn ctrBtn;
    public List<CtrVideo> ctrVideos;
    public CtrlScreenCastShow ctrlScreenCastShow;
    public List<CtrlScreenVideoPlayer> ctrlScreenVideoPlayers;
    private CtrlScreenVideoPlayer ctrlScreenVideoPlayer;
    private string keyName = "";
    public override void HandleMsg(string msg)
    {
        var splitedMsg = msg.Split(':');
        var operation = splitedMsg[0];
        var param = splitedMsg[1];
        //msg = msg.Split(':')[1];

        
        switch (operation)
        {
            case "btnName":
                ctrBtn.OnClickBtn(param);
                foreach (var item in ctrVideos)
                {
                    if (item.name == param)
                    {
                        item.OnLodeScene();
                        break;
                    }
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
                if (keyName == Close[1])
                {
                    ctrlScreenCastShow.EndScreenCast();
                    keyName = "";
                }
                break;
        }
        
    }
}
