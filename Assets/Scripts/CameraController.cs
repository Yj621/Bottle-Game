using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform bottleCap;
    public static CameraController instance;
    private static CameraController Instance
    {
        get { return instance; }
    }


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }

    void Update()
    {
        
    }

    public void FollowCamera(Transform bottle)
    {
        transform.SetParent(bottle);
    }
    public void ReturnCamera()
    {
        transform.SetParent(null);
        //ī�޶� �ٽ� ���󺹱� ��ġ
        transform.position = new Vector3(4.6f, 1.25f, 0.29f);
    }
}
