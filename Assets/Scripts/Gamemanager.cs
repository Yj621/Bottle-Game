using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject bottlePrefab;
    public static Gamemanager instance;
    private static Gamemanager Instance
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

    public void CreateBottle()
    {
        Instantiate(bottlePrefab, new Vector3(4.3f, 0.88f, 0.31f), Quaternion.Euler(-90, 0, 0));
    }
}
