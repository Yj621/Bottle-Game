using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Distance : MonoBehaviour
{
    public GameObject LineA;
    public GameObject LineB;
    public GameObject[] player;

    private Vector3 LineBA;
    private Vector3 LineCA;
    public Vector3[] playerDist;

    public float Score;
    


    public static Distance instance;
    private static Distance Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LineBA = LineB.transform.position - LineA.transform.position;
    }

    void Update()
    {
    }

    //거리구하는 함수
    public void DistanceLine()
    {
        //Bottle을 태그로 찾아서 배열로 만들어줌
        player = GameObject.FindGameObjectsWithTag("Bottle");
        playerDist = new Vector3[player.Length];

        for (int i = 0; i < player.Length; i++)
        {
            playerDist[i] = player[i].transform.position;
            LineCA = playerDist[i] - LineA.transform.position;

            // Vector3.Cross 외적 값 구하기 (수직인값 구하기 : 병뚜껑과 선의 거리)
            float Distance = Vector3.Cross(LineCA, LineBA).magnitude / LineBA.magnitude;
            Distance *= 2;
            Score += (float)Math.Round(Distance, 2);

            if(player[i].GetComponent<BottleCapController>().isStay)
            {
                Gamemanager.instance.bottleCount++;
            }
            
        }
        SaveScore();
    }

    public void SaveScore()
    {
        float highScore = PlayerPrefs.GetFloat("highScore", 0);
        if(Score > highScore)
        {
            PlayerPrefs.SetFloat("highScore", Score);
            PlayerPrefs.Save();
        }

        string currentScoreString = Score.ToString();
        string savedScoreString = PlayerPrefs.GetString("highScore", "");

        if(savedScoreString == "")
        {
            PlayerPrefs.SetString("highScore", currentScoreString);
        }
        else
        {
            string[] scoreArray = savedScoreString.Split(',');
            List<string> scoreList = new List<string>(scoreArray);

            for(int i =0; i< scoreList.Count; i++)
            {
                float savedScore = float.Parse(scoreList[i]);   
                
                if(savedScore < Score)
                {
                    scoreList.Insert(i, currentScoreString);
                    break;
                }
            }
            if(scoreArray.Length == scoreList.Count)
            {
                scoreList.Add(currentScoreString);
            }
            if(scoreList.Count > 3)
            {
                scoreList.RemoveAt(3);
            }
            string result = string.Join(",", scoreList);
            Debug.Log(result);
            PlayerPrefs.SetString("highScore", result);
        }

    }
}
