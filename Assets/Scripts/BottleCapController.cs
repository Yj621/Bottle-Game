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
        //마우스를 누르고 있을때
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = cam.WorldToScreenPoint(transform.position).z;
            dragStartPos = cam.ScreenToWorldPoint(mousePos);
            Debug.Log("dragStartPos : " + dragStartPos);
        }
        //마우스를 뗐을때
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
        //드래그한 값을 빼서 넣어줌
        Vector3 dragVector = dragEndPos - dragStartPos;
        //드래그한 값의 x, y축 좌표를 가져와줌
        Vector3 vec = new Vector3(dragVector.x,0, dragVector.z);

        //x * 힘만큼 앞으로 이동
        rigd.AddForce(vec * power*-1);
    }

}
