
using UnityEngine.UI;

public class DistributionTCPMsgHandler : TCPMsgHandler
{

    public Image bigImage;

    public override void HandleMsg(string msg)
    {
        var splitedMsg = msg.Split(':');
        var operation = splitedMsg[0];
        var param = splitedMsg[1];
        switch (operation)
        {
            case "screen":
                bigImage.enabled = param == "big";
                break;
        }
    }
}
