using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SelectionController : MonoBehaviour
{
    public TextMeshProUGUI[] text;
    void Start()
    {
        List<string> list = new List<string>() {"���Ѳ� ����+1", "+�ӵ�", "+������","-������"};
        

        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(0, 4);
            text[i].text = list[random];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
