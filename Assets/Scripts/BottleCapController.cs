using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCapController : MonoBehaviour
{
    public Rigidbody rigd;
    public Camera cam;

    private Vector3 dragStartPos;
    private Vector3 dragEndPos;

    public float power = 10f;


    void Update()
    {
        //���콺�� ������ ������
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = cam.WorldToScreenPoint(transform.position).z;
            dragStartPos = cam.ScreenToWorldPoint(mousePos);
            Debug.Log("dragStartPos : " + dragStartPos);
        }
        //���콺�� ������
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = cam.WorldToScreenPoint(transform.position).z;
            dragEndPos = cam.ScreenToWorldPoint(mousePos);
            Debug.Log("dragEndPos : " + dragEndPos);
            Shoot();
        }
    }

    void Shoot()
    {
        //�巡���� ���� ���� �־���
        Vector3 dragVector = dragEndPos - dragStartPos;
        //�巡���� ���� x, y�� ��ǥ�� ��������
        Vector3 vec = new Vector3(dragVector.x,0, dragVector.z);

        //x * ����ŭ ������ �̵�
        rigd.AddForce(vec * power*-1);
    }

}
