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

    public GameObject bottlePrefab;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //���Ѳ��� �ӵ� �ľ�
        float speed = rigidbody.velocity.magnitude;

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

            if (selectText.text == "���Ѳ� ����+1" && isCreate == true)
            {
                isCreate = false;
                //���Ѳ��� ���� ��ġ�� �ϳ� ����
                GameObject currentBottle=Instantiate(bottlePrefab, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));

                //���߿� ��ġ��(�ʹ���������)
                Vector3 direction = rigidbody.velocity; 
                currentBottle.GetComponent<Rigidbody>().AddForce(direction/100); 
            }
            if (selectText.text == "+�ӵ�")
            {
                Vector3 direction = rigidbody.velocity;

                //������ ���� ��
                rigidbody.AddForce(direction.normalized * 0.1f);

            }
            if (selectText.text == "+������")
            {
                rigidbody.drag += 5;
            }
            if (selectText.text == "-������")
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
