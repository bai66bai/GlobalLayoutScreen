
using System.Collections.Generic;

public class GlobalTcpMsgHandler : TCPMsgHandler
{
    public CtrBtn ctrBtn;
    public List<CtrVideo> ctrVideos;

    public override void HandleMsg(string msg)
    {


        msg = msg.Split(':')[1];
        ctrBtn.OnClickBtn(msg);
        foreach (var item in ctrVideos)
        {
            if(item.name == msg)
            {
                item.OnLodeScene();
                break;
            } 
        }
    }
}
