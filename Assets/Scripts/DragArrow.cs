using Kalkatos.DottedArrow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DragArrow : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Rigidbody rigd;
    private Camera cam;
    public AudioSource bottleHitSound;
    public GameObject arrow;
    public GameObject canvas;

    private Vector3 dragStartPos;
    private Vector3 dragEndPos;

    private Vector3 dragPos;

    public float power = 10f;
    public float arrowMinHeight = 150f;
    public float arrowMaxHeight = 300f;

    [SerializeField] private GameObject bottle;

    void Start()
    {
        cam = Camera.main;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Gamemanager.instance.hp > 0)
        {
            //���콺 ������ ����������
            //Start Pos ��ȯ
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = cam.WorldToScreenPoint(transform.position).z;
            dragStartPos = cam.ScreenToWorldPoint(mousePos);

        }
    }

    //�巡�� �� ��� ȣ��
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.WorldToScreenPoint(transform.position).z;
        dragPos = cam.ScreenToWorldPoint(mousePos);

        //�巡�� �Ÿ� ���
        float dragDistance = Vector3.Distance(dragStartPos, dragPos);

        //arrowHeight��(dragDistance * 1000�� ���� ����) �ּҰ����� ������ min, �ִ밪���� ũ�� max�� ��ȯ
        float arrowHeight = Mathf.Clamp(dragDistance * 2000f, arrowMinHeight, arrowMaxHeight);
        RectTransform rectTransform = arrow.GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, arrowHeight);

        Vector3 dragDirection = dragPos - dragStartPos;
        if (dragDirection != Vector3.zero)
        {
            // LookRotation(Vector3 forward, Vector3 upwards, Vector3 up)
            // �ش� ������Ʈ�� Vector3 �������� ���ϰԲ� ���ش�
            arrow.transform.rotation = Quaternion.LookRotation(new Vector3(dragDirection.x, 10, dragDirection.z));
        }
    }

    //�巡�� ���� �� ȣ��
    public void OnEndDrag(PointerEventData eventData)
    {

        //���콺�� ������
        //End Pos ��ȯ
        if (Gamemanager.instance.hp > 0)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = cam.WorldToScreenPoint(transform.position).z;
            dragEndPos = cam.ScreenToWorldPoint(mousePos);

            //�巡�� ���� ����
            dragEndPos.x = Mathf.Clamp(dragEndPos.x, 4.12f, 4.4f);
            dragEndPos.y = Mathf.Clamp(dragEndPos.y, 1.13f, 1.47f);
            dragEndPos.z = Mathf.Clamp(dragEndPos.z, 0.06f, 0.5f);


            Shoot();
            Gamemanager.instance.DecreaseHp();

            // DecreaseHp() ȣ�� �� hp�� �ٽ� üũ
            if (Gamemanager.instance.hp > 0)
            {
                //��� ���� ���Ѳ��� �� �����϶� ���� ���Ѳ� ����
                //(���� �� ��)
                Invoke("Create", 1.5f);
            }

        }
       
    }

    void Create()
    {
        Gamemanager.instance.CreateBottle();
        CameraController.instance.ReturnCamera();
    }

    void Shoot()
    {
        bottleHitSound.Play();
        bottle.GetComponent<BottleCapController>().isCreate = true;
        CameraController.instance.FollowCamera(bottle.transform);
        //�巡���� ���� ���� �־���
        Vector3 dragVector = dragEndPos - dragStartPos;
        //�巡���� ���� x, y�� ��ǥ�� ��������
        Vector3 vec = new Vector3(dragVector.x, 0, dragVector.z);

        //x * ����ŭ ������ �̵�
        rigd.AddForce(vec * power * -1);

        //�� �� ������ ȭ��ǥ �� ���̰�
        canvas.gameObject.SetActive(false);
    }

}