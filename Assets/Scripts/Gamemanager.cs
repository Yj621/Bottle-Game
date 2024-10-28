using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject bottlePrefab;
    public static Gamemanager instance;
    private static Gamemanager Instance
    {
        get { return instance; }
    }

    public GameObject[] hp_img;
    public int hp = 3;
    private int currentHpIndex;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHpIndex = hp_img.Length - 1;
        CreateBottle();
    }

    void Update()
    {
        
    }

    public void CreateBottle()
    {
        Instantiate(bottlePrefab, new Vector3(4.3f, 0.88f, 0.31f), Quaternion.Euler(-90, 0, 0));
    }
    public void DecreaseHp()
    {
        if (currentHpIndex >= 0)
        {
            hp_img[currentHpIndex].SetActive(false);
            currentHpIndex--;
            hp--;
        }
    }

}
