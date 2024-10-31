using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BottleCapController : MonoBehaviour
{
    Rigidbody rigidbody;

    public float power = 10f;

    public bool isStay = false;
    public bool isCreate = false;

    public GameObject bottlePrefab;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //º´¶Ñ²±ÀÇ ¼Óµµ ÆÄ¾Ç
        float speed = rigidbody.velocity.magnitude;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            isStay = true;
        }
        else
        {
            isStay = false;
        }
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
        if (other.gameObject.CompareTag("Selection"))
        {
            TextMeshProUGUI selectText = other.transform.parent.GetComponent<TextMeshProUGUI>();

            if (selectText.text == "º´¶Ñ²± °³¼ö+1" && isCreate == true)
            {
                isCreate = false;
                //º´¶Ñ²±À» °°Àº À§Ä¡¿¡ ÇÏ³ª »ý¼º
                GameObject currentBottle = Instantiate(bottlePrefab, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));

                //³ªÁß¿¡ °íÄ¡±â(³Ê¹«»¡¸®³¯¶ó°¨)
                Vector3 direction = rigidbody.velocity;
                currentBottle.GetComponent<Rigidbody>().AddForce(direction / 100);
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

}
