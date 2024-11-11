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
    /// 控制按钮的样式
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

    private void changeContent(int index)
    {
        if (index == 0)
        {

            VLCPlayerExample[] vLCPlayer1Examples = Hangzhou.GetComponentsInChildren<VLCPlayerExample>();
            foreach (var item in vLCPlayer1Examples)
            {
                item.DestroyMediaPlayer();
            }
            foreach (Transform childTransform in Hangzhou.transform)
            {
                Destroy(childTransform.gameObject);
            }
            Contents[0].SetActive(true);
            Suzhou.GetComponent<CtrVideoPrefab>().LoadPrefabSync();
            IsReleasingSuZhou = false;
            IsReleasingHangZhou = true;
        }
        else
        {

            VLCPlayerExample[] vLCPlayer1Examples = Suzhou.GetComponentsInChildren<VLCPlayerExample>();
            foreach (var item in vLCPlayer1Examples)
            {
                item.DestroyMediaPlayer();
            }
            foreach (Transform childTransform in Suzhou.transform)
            {
                Destroy(childTransform.gameObject);
            }
            Contents[1].SetActive(true);
           Hangzhou.GetComponent<CtrVideoPrefab>().LoadPrefabSync();
            IsReleasingSuZhou = true;
            IsReleasingHangZhou = false;
        }
    }
}
