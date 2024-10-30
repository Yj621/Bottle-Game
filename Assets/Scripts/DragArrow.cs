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
            //마우스 누르기 시작했을때
            //Start Pos 반환
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = cam.WorldToScreenPoint(transform.position).z;
                dragStartPos = cam.ScreenToWorldPoint(mousePos);
            }

            //마우스 누르고 있을때
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = cam.WorldToScreenPoint(transform.position).z;
                dragPos = cam.ScreenToWorldPoint(mousePos);

                //드래그 거리 계산
                float dragDistance = Vector3.Distance(dragStartPos, dragPos);

                //arrowHeight을(dragDistance * 1000을 곱한 값이) 최소값보다 작으면 min, 최대값보다 크면 max을 반환
                float arrowHeight = Mathf.Clamp(dragDistance * 5000f, arrowMinHeight, arrowMaxHeight);
                RectTransform rectTransform = arrow.GetComponent<RectTransform>();
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, arrowHeight);

                Vector3 dragDirection = dragPos - dragStartPos;
                if (dragDirection != Vector3.zero)
                {
                    // LookRotation(Vector3 forward, Vector3 upwards, Vector3 up)
                    // 해당 오브젝트가 Vector3 방향으로 향하게끔 해준다
                    arrow.transform.rotation = Quaternion.LookRotation(new Vector3(dragDirection.x, 3, dragDirection.z));
                }
            }

            //마우스를 뗐을때
            //End Pos 반환
            if (Input.GetMouseButtonUp(0) && Gamemanager.instance.hp > 0)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = cam.WorldToScreenPoint(transform.position).z;
                dragEndPos = cam.ScreenToWorldPoint(mousePos);


                Shoot();
                Gamemanager.instance.DecreaseHp();

                // DecreaseHp() 호출 후 hp를 다시 체크
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
        //드래그한 값을 빼서 넣어줌
        Vector3 dragVector = dragEndPos - dragStartPos;
        //드래그한 값의 x, y축 좌표를 가져와줌
        Vector3 vec = new Vector3(dragVector.x, 0, dragVector.z);

        //x * 힘만큼 앞으로 이동
        rigd.AddForce(vec * power * -1);
        isTrigger = true;

        //한 번 날리면 화살표 안 보이게
        canvas.gameObject.SetActive(false);
    }

}
