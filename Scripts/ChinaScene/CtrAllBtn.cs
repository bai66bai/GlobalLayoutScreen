using System.Collections.Generic;
using UnityEngine;


public class CtrAllBtn : MonoBehaviour
{
    public List<Transform> BtnTransforms;
    public Transform PopupWindow;
    public List<GameObject> RegionalInformations;
    public Transform BgPanel;
    public List<GameObject> Details;

    //���Ƶ�һ�ε����ť��������
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
    /// ���ƻ�ԭ��ǰ���ҽ���
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
    /// ������Ļ�����Լ��������ĳ���
    /// </summary>
    /// <param name="IsStart">�ж��ǵ������ǻָ�</param>
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
