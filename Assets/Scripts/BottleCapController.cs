using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BottleCapController : MonoBehaviour
{
    public float power = 10f;
    Rigidbody rigidbody;

    bool isStay = false;
    public bool isCreate = false;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            isStay = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            isStay = true;
            Invoke("Clear", 1f);
        }
        if (!other.gameObject.CompareTag("Line") && Gamemanager.instance.hp <= 0)
        {
            Debug.Log("Fail");
            Invoke("Fail", 1f);
        }

        if (other.gameObject.CompareTag("Selection"))
        {
            TextMeshProUGUI selectText = other.transform.parent.GetComponent<TextMeshProUGUI>();

            if (selectText.text == "º´¶Ñ²± °³¼ö+1" && isCreate == true)
            {
                isCreate = false;
                //º´¶Ñ²±À» °°Àº À§Ä¡¿¡ ÇÏ³ª »ý¼º
                Instantiate(gameObject, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
            }
            if (selectText.text == "+¼Óµµ")
            {
                Vector3 direction = rigidbody.velocity;

                //¾ÕÀ¸·Î ÈûÀ» ÁÜ
                rigidbody.AddForce(direction.normalized * 0.1f);

            }
            if (selectText.text == "+¸¶Âû·Â")
            {
                rigidbody.drag += 5;
            }
            if (selectText.text == "-¸¶Âû·Â")
            {
                rigidbody.drag /= 2;
            }
        }
    }
    public void Clear()
    {
        if (isStay == true)
        {
            EndScript.instance.OnWinPanel();
        }
    }
    public void Fail()
    {
        EndScript.instance.OnLosePanel();
    }
}
