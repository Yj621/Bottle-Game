using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public GameObject bottlePrefab;
    public GameObject canvas;
    public GameObject[] hp_img;

    public int bottleCount = 0;

    public int hp = 3;
    private int currentHpIndex;

    public static Gamemanager instance;
    private static Gamemanager Instance
    {
        get { return instance; }
    }
    EndScript endScript;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHpIndex = hp_img.Length - 1;
        CreateBottle();
        endScript = canvas.GetComponent<EndScript>();
    }

    void Update()
    {
        //hp가 0이 됐을때 클리어함수로
        if (hp == 0)
        {
            hp--;
            StartCoroutine(ClearRoutine());
        }
    }

    IEnumerator ClearRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        endScript.Clear();
    }

    public void CreateBottle()
    {
       Instantiate(bottlePrefab, new Vector3(4.3f, 1.56f, 0.28f), Quaternion.Euler(-90, 0, 0));
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
    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
