using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleOnStart : MonoBehaviour
{
    public GameObject MainObj;
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "IdleScene")
            MainObj.SetActive(true);
    }
}
