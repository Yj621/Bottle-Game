using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject[] hp_img;
    private int currentHpIndex;

    public static UIController instance;
    private static UIController Instance
    {
        get { return instance; }
    }
    void Start()
    {
        currentHpIndex = hp_img.Length-1;
    }

    void Update()
    {
        
    }
    public void DecreaseHp()
    {
        if(currentHpIndex >=0)
        {
            hp_img[currentHpIndex].SetActive(false);
            currentHpIndex--;
        }
    }
}
