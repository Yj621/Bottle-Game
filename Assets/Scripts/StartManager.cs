using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    private GameObject RankPanel;
    void Start()
    {
    }

    void Update()
    {
    }
    public void OnClickRank()
    {
        RankPanel.SetActive(true);
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("PlayScene");
    }

}
