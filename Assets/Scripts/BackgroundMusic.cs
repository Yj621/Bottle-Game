using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource backmusic;
    void Awake()
    {
        backmusic = gameObject.GetComponent<AudioSource>(); //배경음악 저장해둠
        DontDestroyOnLoad(backmusic); //배경음악 계속 재생하게(이후 버튼매니저에서 조작)
        
    }
}