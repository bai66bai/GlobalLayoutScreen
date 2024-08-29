using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryTcpMsgHandler : TCPMsgHandler
{

    public CtrAllBtn CtrAllBtn;
    public List<GameObject> CityList;
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
            case "btnName":
                CtrAllBtn.ClickBtn(param);
                break;
            case "big":
            case "small":
                foreach (var item in CityList)
                {
                    if (item.name == param)
                    {
                        CtrImgScale targetCtr = item.GetComponentInChildren<CtrImgScale>();
                        targetCtr.OnClick();
                    }
                }
                break;
            case "operationName":
                CtrAllBtn.CtrlRecovery();
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
