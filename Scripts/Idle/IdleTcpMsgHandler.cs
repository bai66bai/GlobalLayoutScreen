using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTcpMsgHandler : TCPMsgHandler
{
    private LevelLoader levelLoader;

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
                if (param != "MenuScene") levelLoader.LoadNewScene(param);
                break;
        }
    }
}
