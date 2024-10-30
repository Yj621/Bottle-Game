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

    public void FollowCamera()
    {
        transform.SetParent(bottleCap);
    }
    public void ReturnCamera()
    {
        transform.SetParent(null);
    }
}
