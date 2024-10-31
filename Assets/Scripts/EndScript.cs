using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    [SerializeField]
    private GameObject RankPanel;
    [SerializeField]
    private GameObject ResultPanel;
    [SerializeField]
    private GameObject[] Star;
    [SerializeField]
    private GameObject Effect;

    [SerializeField]
    private Sprite FailImg;
    Image changeImg;
    Sprite starImg;
    [SerializeField]
    private Image[] BottleSuccess;
    [SerializeField]
    private Sprite XImg;
    [SerializeField]
    private Sprite HeartImg;

    public static EndScript instance;

    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private TMP_Text ScoreText;

    BottleCapController bottleScript;

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
        bottleScript = FindAnyObjectByType<BottleCapController>();
    }

    void Update()
    {
    }
    public void OnRankPanel()
    {
        RankPanel.SetActive(true);
    }
    public void OnResultPanel()
    {
        ResultPanel.SetActive(true);
    }


    public void OffRankPanel()
    {
        RankPanel.SetActive(false);
    }
    public void OffResultPanel()
    {
        ResultPanel.SetActive(false);
    }

    public void Clear()
    {
        Distance.instance.DistanceLine();
        if (Gamemanager.instance.bottleCount > 0)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    public void Win()
    {
        OnResultPanel();
        //���� ����
        titleText.text = "YOU WIN";

        //���ھ� ǥ��
        ScoreText.text = Distance.instance.Score.ToString();

        //�ڿ� ȿ�� ǥ��
        Effect.SetActive(true);

        //�� ��Ÿ����
        for (int i = 0; i < Star.Length; i++)
        {
            Star[i].SetActive(true);
        }
        changeImg = Star[2].GetComponent<Image>();
        starImg = Star[1].GetComponent<Image>().sprite;
        changeImg.sprite = starImg;

        for (int i = 0; i < BottleSuccess.Length; i++)
        {
            //�ʱ�� ��� x��
            BottleSuccess[i].sprite = XImg;
        }

        for (int i = 0; i < Math.Min(Gamemanager.instance.bottleCount, 3); i++)
        {
            //���Ѳ��� �� �ȿ� ���߸� ������ŭ ��Ʈ�� �ٲ�
            BottleSuccess[i].sprite = HeartImg;
        }
    }
    public void Lose()
    {
        OnResultPanel();
        //���� ����
        titleText.text = "YOU LOSE";

        //���ھ� ǥ��
        ScoreText.text = Distance.instance.Score.ToString();

        //�ڿ� ȿ�� ǥ��
        Effect.SetActive(false);

        //�� �������
        for (int i = 0; i < Star.Length - 1; i++)
        {
            Star[i].SetActive(false);
        }

        //�ذ� �̹����� ����
        changeImg = Star[2].GetComponent<Image>();
        changeImg.sprite = FailImg;

        //���Ѳ��� �� �ȿ� �ƹ��͵� �� �������� X �̹����� ����
        for (int i = 0; i < BottleSuccess.Length; i++)
        {
            BottleSuccess[i].sprite = XImg;
        }
    }
}
