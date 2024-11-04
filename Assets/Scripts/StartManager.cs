using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartManager : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("PlayScene");
    }

}
