using Kalkatos.DottedArrow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragArrow : MonoBehaviour
{
    public Rigidbody rigd;
    private Camera cam;
    public GameObject arrow;
    public GameObject canvas;

    private Vector3 dragStartPos;
    private Vector3 dragEndPos;

    private Vector3 dragPos;

    public float power = 10f;
    public float arrowMinHeight = 150f;
    public float arrowMaxHeight = 300f;

    public bool isTrigger;
    [SerializeField] private GameObject bottleScript;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!isTrigger && Gamemanager.instance.hp > 0)
        {
            //���콺 ������ ����������
            //Start Pos ��ȯ
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = cam.WorldToScreenPoint(transform.position).z;
                dragStartPos = cam.ScreenToWorldPoint(mousePos);
            }

            //���콺 ������ ������
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = cam.WorldToScreenPoint(transform.position).z;
                dragPos = cam.ScreenToWorldPoint(mousePos);

                //�巡�� �Ÿ� ���
                float dragDistance = Vector3.Distance(dragStartPos, dragPos);

                //arrowHeight��(dragDistance * 1000�� ���� ����) �ּҰ����� ������ min, �ִ밪���� ũ�� max�� ��ȯ
                float arrowHeight = Mathf.Clamp(dragDistance * 5000f, arrowMinHeight, arrowMaxHeight);
                RectTransform rectTransform = arrow.GetComponent<RectTransform>();
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, arrowHeight);

                Vector3 dragDirection = dragPos - dragStartPos;
                if (dragDirection != Vector3.zero)
                {
                    // LookRotation(Vector3 forward, Vector3 upwards, Vector3 up)
                    // �ش� ������Ʈ�� Vector3 �������� ���ϰԲ� ���ش�
                    arrow.transform.rotation = Quaternion.LookRotation(new Vector3(dragDirection.x, 3, dragDirection.z));
                }
            }

            //���콺�� ������
            //End Pos ��ȯ
            if (Input.GetMouseButtonUp(0) && Gamemanager.instance.hp > 0)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = cam.WorldToScreenPoint(transform.position).z;
                dragEndPos = cam.ScreenToWorldPoint(mousePos);


                Shoot();
                Gamemanager.instance.DecreaseHp();

                // DecreaseHp() ȣ�� �� hp�� �ٽ� üũ
                if (Gamemanager.instance.hp > 0)
                {
                    Invoke("Create", 5f);
                }
            }
        }
    }
    void Create()
    {
        Gamemanager.instance.CreateBottle();
    }

    void Shoot()
    {
        //CameraController.instance.FollowCamera();
        bottleScript.GetComponent<BottleCapController>().isCreate = true;
        //�巡���� ���� ���� �־���
        Vector3 dragVector = dragEndPos - dragStartPos;
        //�巡���� ���� x, y�� ��ǥ�� ��������
        Vector3 vec = new Vector3(dragVector.x, 0, dragVector.z);

        //x * ����ŭ ������ �̵�
        rigd.AddForce(vec * power * -1);
        isTrigger = true;

        //�� �� ������ ȭ��ǥ �� ���̰�
        canvas.gameObject.SetActive(false);
    }

}
