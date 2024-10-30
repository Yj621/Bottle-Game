using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SelectionController : MonoBehaviour
{
    public TextMeshProUGUI[] text;
    public GameObject[] selections;
    public static SelectionController instance;
    private static SelectionController Instance
    {
        get { return instance; }
    }
    void Start()
    {
        List<string> list = new List<string>() { "º´¶Ñ²± °³¼ö+1", "+¼Óµµ", "+¸¶Âû·Â", "-¸¶Âû·Â" };


        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(0, 4);
            text[i].text = list[random];
        }
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {


    }
}
