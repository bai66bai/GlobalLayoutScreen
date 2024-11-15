﻿using UnityEngine;

public  class TCPMsgHandler : MonoBehaviour
{
    private LevelLoader levelLoader;
    private void Awake()
    {
        levelLoader = GetComponent<LevelLoader>();
    }

    public virtual void HandleMsg(string msg) { }

    public virtual void OnMsg(string msg) 
    {
        string[] splitMsg = msg.Split(":");
        if (splitMsg[0] == "loadScene")
        {
            levelLoader.LoadNewScene(splitMsg[1]);
            return;
        }else if(splitMsg[0] == "loadSceneNoAnimation")
        {
            levelLoader.LoadSceneNoAnimation(splitMsg[1]);
        }
        HandleMsg(msg);
    }
}

