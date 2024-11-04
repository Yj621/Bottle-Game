using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] audios;

    public static Audios instance;
    private static Audios Instance
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
    
    public void SuccessSound()
    {
        audios[0].Play();
    }
    public void FailSound()
    {
        audios[1].Play();
    }
    public void ButtonClickSound()
    {
        audios[2].Play();
    }

}
