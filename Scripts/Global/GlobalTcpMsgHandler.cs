
using System.Collections.Generic;
using System.Diagnostics;

public class GlobalTcpMsgHandler : TCPMsgHandler
{
    public CtrBtn ctrBtn;
    public List<CtrVideo> ctrVideos;
    public CtrlScreenCastShow ctrlScreenCastShow;
    public List<CtrlScreenVideoPlayer> ctrlScreenVideoPlayers;
    private CtrlScreenVideoPlayer ctrlScreenVideoPlayer;
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
