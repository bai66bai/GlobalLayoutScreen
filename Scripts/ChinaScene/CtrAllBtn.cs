using System.Collections.Generic;
using UnityEngine;


public class CtrAllBtn : MonoBehaviour
{
    public List<Transform> BtnTransforms;
    public Transform PopupWindow;
    public List<GameObject> RegionalInformations;
    public Transform BgPanel;
    public List<GameObject> Details;

    //控制第一次点击按钮缓慢缩放
    private bool isFrist = true;

    public void ClickBtn(string name)
    {
        CtrlScalseAndMove(true);
        BtnTransforms.ForEach(u =>
        {
            CtrBtnChange ctrBtnChange = u.GetComponent<CtrBtnChange>();

            if (name == u.name)
            {
                int index = BtnTransforms.IndexOf(u);
                ShowInFormations(index);
                ctrBtnChange.SelectBtn(true);
            }
            else
            {
                ctrBtnChange.UnSelectedBtn(isFrist);
            }
        });
        isFrist = false;
    }



    /// <summary>
    /// 控制还原当前国家界面
    /// </summary>
    public void CtrlRecovery()
    {
        CtrlScalseAndMove(false);
        BtnTransforms.ForEach(u =>
        {
            CtrBtnChange ctrBtnChange = u.GetComponent<CtrBtnChange>();
            int index = BtnTransforms.IndexOf(u);
            ctrBtnChange.SelectBtn(false);
        });
    }

    /// <summary>
    /// 控制屏幕缩放以及弹出窗的出现
    /// </summary>
    /// <param name="IsStart">判断是弹出还是恢复</param>
    private void CtrlScalseAndMove(bool IsStart)
    {
        if (IsStart)
        {
            PopupWindow.GetComponent<CtrPopupWiindow>().StartMove();
            BgPanel.GetComponent<CtrBgScale>().ClickBtnSCale();
        }
        else
        {
            PopupWindow.GetComponent<CtrPopupWiindow>().StartMoveEnd();
            BgPanel.GetComponent<CtrBgScale>().ClickBtnSCaleEnd();
        }
    }


    public void ShowInFormations(int index)
    {
        RegionalInformations.ForEach(u =>
        {
            int sindex = RegionalInformations.IndexOf(u);
            u.SetActive(index == sindex);
        });
    }
}
