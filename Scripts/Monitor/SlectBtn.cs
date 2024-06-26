using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBtn : MonoBehaviour
{
    public LevelLoader LevelLoader;

    public void TabSelect(int index)
    {
        TabStore.SelectedTab = index;
        LevelLoader.LoadNewScene("EnterMonitorScene", false); 
    }
}
