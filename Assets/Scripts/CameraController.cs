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
        //카메라 다시 원상복구 위치
        transform.position = new Vector3(4.9f, 1.88f, 0.25f);
    }
}
