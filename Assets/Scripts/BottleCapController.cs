using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCapController : MonoBehaviour
{
    public Rigidbody rigd;
    public Camera cam;
    public GameObject arrow;

    private Vector3 dragStartPos;
    private Vector3 dragEndPos;

    private Vector3 dragPos;

    public float power = 10f;
    public float arrowMinHeight = 150f;
    public float arrowMaxHeight = 300f;

    public bool isTrigger;

    private void Start()
    {
    }

    void Update()
    {
        if (!isTrigger)
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
                float arrowHeight = Mathf.Clamp(dragDistance * 1000f, arrowMinHeight, arrowMaxHeight);
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
            if (Input.GetMouseButtonUp(0))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = cam.WorldToScreenPoint(transform.position).z;
                dragEndPos = cam.ScreenToWorldPoint(mousePos);
                Shoot();
            }
        }
    }

    void Shoot()
    {
        //�巡���� ���� ���� �־���
        Vector3 dragVector = dragEndPos - dragStartPos;
        //�巡���� ���� x, y�� ��ǥ�� ��������
        Vector3 vec = new Vector3(dragVector.x, 0, dragVector.z);

        //x * ����ŭ ������ �̵�
        rigd.AddForce(vec * power * -1);
        isTrigger = true;
        arrow.gameObject.SetActive(false);
    }

}
