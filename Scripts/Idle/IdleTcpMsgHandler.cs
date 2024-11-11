using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTcpMsgHandler : TCPMsgHandler
{
    private LevelLoader levelLoader;
    public CtrlScreenCastShow ctrlScreenCastShow;
    public List<CtrlScreenVideoPlayer> ctrlScreenVideoPlayers;
    private CtrlScreenVideoPlayer ctrlScreenVideoPlayer;
    private string keyName = "";
    private void Start()
    {
        levelLoader = GetComponent<LevelLoader>();
    }

    public override void HandleMsg(string msg)
    {
        var splitedMsg = msg.Split(':');
        var operation = splitedMsg[0];
        var param = splitedMsg[1];
        switch (operation)
        {
            case "cityIndex":
                TabStore.SelectedTab = int.Parse(param);
                levelLoader.LoadNewScene("EnterMonitorScene");
                break;
            case "sceneName":
                levelLoader.LoadNewScene(param);
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
