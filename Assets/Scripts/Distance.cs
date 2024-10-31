using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Distance : MonoBehaviour
{
    public GameObject LineA;
    public GameObject LineB;

    private Vector3 LineBA;
    private Vector3 LineCA;
    public Vector3[] playerDist;
    private float Score;

    public GameObject[] player;

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

    //�Ÿ����ϴ� �Լ�
    public void DistanceLine()
    {
        //Bottle�� �±׷� ã�Ƽ� �迭�� �������
        player = GameObject.FindGameObjectsWithTag("Bottle");
        playerDist = new Vector3[player.Length];

        for (int i = 0; i < player.Length; i++)
        {
            playerDist[i] = player[i].transform.position;
            LineCA = playerDist[i] - LineA.transform.position;

            // Vector3.Cross ���� �� ���ϱ� (�����ΰ� ���ϱ� : ���Ѳ��� ���� �Ÿ�)
            float Distance = Vector3.Cross(LineCA, LineBA).magnitude / LineBA.magnitude;
            Distance *= 2;
            Score += (float)Math.Round(Distance, 2);
        }
    }

    public void CalScore()
    {
        
    }
}
