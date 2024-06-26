using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CtrBtnsEM : MonoBehaviour
{
    public List<GameObject> Btns;
    public List<GameObject> Contents;

    public GameObject Suzhou;
    public GameObject Hangzhou;

    [HideInInspector]
    public bool IsReleasingSuZhou = false;
    [HideInInspector]
    public bool IsReleasingHangZhou = false;

    private void Start()
    {
        changeStyle(TabStore.SelectedTab);
        changeContent(TabStore.SelectedTab);
    }

    public void OnClickBtn(string name)
    {
        Btns.ForEach(b =>
        {
            int index = Btns.IndexOf(b);
            if (b.name == name)
            {
                changeStyle(index);
                changeContent(index);
            }
        });
    }


    /// <summary>
    /// ���ư�ť����ʽ
    /// </summary>
    /// <param name="index"></param>
    private void changeStyle(int index)
    {
        Btns.ForEach(b =>
        {
            int bindex = Btns.IndexOf(b);
            if (bindex == index)
            {
                TextMeshProUGUI text = b.GetComponentInChildren<TextMeshProUGUI>();
                text.color = Color.white;
                Image[] images = b.GetComponentsInChildren<Image>();
                images[0].enabled = true;
                images[1].enabled = false;
            }
            else
            {
                TextMeshProUGUI text = b.GetComponentInChildren<TextMeshProUGUI>();
                text.color = new Color(47 / 255f, 92 / 255f, 197 / 255f, 1f);
                Image[] images = b.GetComponentsInChildren<Image>();
                images[1].enabled = true;
                images[0].enabled = false;
            }
        });
    }


    void Update()
    {
 
        if (IsReleasingHangZhou || IsReleasingSuZhou)
        {
            bool hasAllVlcReleased = true;
            foreach (Transform child in IsReleasingSuZhou ? Suzhou.transform : Hangzhou.transform)
            {
                VLCPlayerExample[] vLCPlayerExamples = child.gameObject.GetComponentsInChildren<VLCPlayerExample>();
                foreach (var item in vLCPlayerExamples)
                {
                    if(!item.HasDestroyed)
                    {
                        hasAllVlcReleased = false;
                        break;
                    }
                }                

                if(hasAllVlcReleased)
                {
                    Destroy(child.gameObject);
                    IsReleasingHangZhou = false;
                    IsReleasingSuZhou = false;
                }
            }
        }
    }

    private void changeContent(int index)
    {
        if (index == 0)
        {

            VLCPlayerExample[] vLCPlayer1Examples = Hangzhou.GetComponentsInChildren<VLCPlayerExample>();
            foreach (var item in vLCPlayer1Examples)
            {
                item.DestoryVLCPlayer();
            }
            Contents[0].SetActive(true);
            Suzhou.GetComponent<CtrVideoPrefab>().LoadPrefabSync();
            IsReleasingHangZhou = true;
        }
        else
        {

            VLCPlayerExample[] vLCPlayer1Examples = Suzhou.GetComponentsInChildren<VLCPlayerExample>();
            foreach (var item in vLCPlayer1Examples)
            {
                item.DestoryVLCPlayer();
            }
            Contents[1].SetActive(true);
           Hangzhou.GetComponent<CtrVideoPrefab>().LoadPrefabSync();
            IsReleasingSuZhou = true;
        }
    }
}
