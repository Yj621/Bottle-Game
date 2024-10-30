using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject RankPanel;
    public GameObject LosePanel;
    public GameObject WinPanel;
    public static EndScript instance;
    private static EndScript Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnRankPanel()
    {
        RankPanel.SetActive(true);
    }
    public void OnLosePanel()
    {
        RankPanel.SetActive(true);
    }
    public void OnWinPanel()
    {
        RankPanel.SetActive(true);
    }


    public void OffRankPanel()
    {
        RankPanel.SetActive(false);
    }
    public void OffLosePanel()
    {
        RankPanel.SetActive(false);
    }
    public void OffWinPanel()
    {
        RankPanel.SetActive(false);
    }
}
