using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCapController : MonoBehaviour
{
    public Rigidbody rigd;

    private Vector2 dragStartPos;
    private Vector2 dragEndPos;

    public float power = 10f;

    void Update()
    {
        //���콺�� ������ ������
        if(Input.GetMouseButtonDown(0))
        {
            dragStartPos = Input.mousePosition;
            Debug.Log("dragStartPos : " + dragStartPos);
        }

        //���콺�� ������
        if (Input.GetMouseButtonUp(0))
        {
            dragEndPos = Input.mousePosition;
            Debug.Log("dragEndPos : " + dragEndPos);
            Shoot();
        }
    }

    void Shoot()
    {
        //�巡���� ���� ���� �־���
        Vector2 dragVector = dragEndPos - dragStartPos;
        //�巡���� ���� x, y�� ��ǥ�� ��������
        Vector3 vec = new Vector3(dragVector.x, 0, dragVector.y);

        //x, y�� * ����ŭ ������ �̵�
        rigd.AddForce(vec * power);
    }

}
