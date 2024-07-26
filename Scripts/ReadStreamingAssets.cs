using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class ReadStreamingAssets : MonoBehaviour
{
    public VLCPlayerExample vLCPlayerExampl;
    public string LocalPath;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReadFile());
    }
    IEnumerator ReadFile()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "a.mp4");

        UnityWebRequest www = UnityWebRequest.Get(filePath);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string data = www.downloadHandler.text;
            vLCPlayerExampl.StrartVideo(filePath);
        }
        else
        {
            Debug.LogError("º”‘ÿ ß∞‹£∫ " + www.error);
        }
    }
}
