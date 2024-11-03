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
        //병뚜껑의 속도 파악
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

            if (selectText.text == "병뚜껑 개수+1" && isCreate == true)
            {
                isCreate = false;
                //병뚜껑을 같은 위치에 하나 생성
                GameObject currentBottle = Instantiate(bottlePrefab, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));

                //나중에 고치기(너무빨리날라감)
                Vector3 direction = rigidbody.velocity;
                currentBottle.GetComponent<Rigidbody>().AddForce(direction/30);
            }
            if (selectText.text == "+속도")
            {
                Vector3 direction = rigidbody.velocity;

                //앞으로 힘을 줌
                rigidbody.AddForce(direction.normalized * 0.1f);

            }
            if (selectText.text == "+마찰력")
            {
                rigidbody.drag += 5;
            }
            if (selectText.text == "-마찰력")
            {
                rigidbody.drag /= 2;
            }
        }
    }

}
