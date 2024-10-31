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
        //제목 변경
        titleText.text = "YOU WIN";

        //스코어 표시
        ScoreText.text = Distance.instance.Score.ToString();

        //뒤에 효과 표현
        Effect.SetActive(true);

        //별 나타나게
        for (int i = 0; i < Star.Length; i++)
        {
            Star[i].SetActive(true);
        }
        changeImg = Star[2].GetComponent<Image>();
        starImg = Star[1].GetComponent<Image>().sprite;
        changeImg.sprite = starImg;

        for (int i = 0; i < BottleSuccess.Length; i++)
        {
            //초기는 모두 x로
            BottleSuccess[i].sprite = XImg;
        }

        for (int i = 0; i < Math.Min(Gamemanager.instance.bottleCount, 3); i++)
        {
            //병뚜껑을 선 안에 맞추면 개수만큼 하트로 바뀜
            BottleSuccess[i].sprite = HeartImg;
        }
    }
    public void Lose()
    {
        OnResultPanel();
        //제목 변경
        titleText.text = "YOU LOSE";

        //스코어 표시
        ScoreText.text = Distance.instance.Score.ToString();

        //뒤에 효과 표현
        Effect.SetActive(false);

        //별 사라지게
        for (int i = 0; i < Star.Length - 1; i++)
        {
            Star[i].SetActive(false);
        }

        //해골 이미지로 변경
        changeImg = Star[2].GetComponent<Image>();
        changeImg.sprite = FailImg;

        //병뚜껑을 선 안에 아무것도 못 맞췄으니 X 이미지로 변경
        for (int i = 0; i < BottleSuccess.Length; i++)
        {
            BottleSuccess[i].sprite = XImg;
        }
    }
}
