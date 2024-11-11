using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlScreenCastShow : MonoBehaviour
{
    public List<GameObject> list;

    public void StartScreen(string videoName)
    {
        list.ForEach(item =>
        {
           item.SetActive(item.name == videoName);
        });
    }


    public void EndScreenCast()
    {
        list.ForEach(item => { 
        item.SetActive(false);
        });
    }
}
