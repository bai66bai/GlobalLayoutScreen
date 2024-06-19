using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryTcpMsgHandler : TCPMsgHandler
{

    public CtrAllBtn CtrAllBtn;
    public List<GameObject> CityList;

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
                        Debug.Log(param);
                        CtrImgScale targetCtr = item.GetComponentInChildren<CtrImgScale>();
                        targetCtr.OnClick();
                    }
                }
                break;
        }

    }
}
