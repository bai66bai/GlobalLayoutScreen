using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakIdle : MonoBehaviour
{

    public static bool shouldBreak = false;
    public bool IsIdle { get => gameObject.activeSelf; }

    public static void BreakIdleSync()
    {

        // 隐藏待机场景根对象
        Scene targetScene = SceneManager.GetSceneByName("IdleScene");
        if (targetScene.isLoaded)
        {
            GameObject[] rootObjects = targetScene.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                if (obj.name == "MainObj")
                    obj.SetActive(false);
            }
        }

        // 激活当前场景根对象
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.isLoaded)
        {
            GameObject[] rootObjects = currentScene.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                if (obj.name == "MainObj")
                    obj.SetActive(true);
                else if (obj.name == "LevelLoader")
                    obj.GetComponent<SceneIdle>().ResetTimer();
            }
        }

    }
}
