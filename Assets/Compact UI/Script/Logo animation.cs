using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logoanimation : MonoBehaviour
{
    public Image logoImage; // �ΰ� �̹���
    public float speed = 0.5f; // �̵� �ӵ�
    public float height = 10f; // ���� �ݺ� ����

    private Vector3 startPos;

    void Start()
    {
        startPos = logoImage.transform.localPosition;
    }

    void Update()
    {
        // ���Ϸ� �����̴� �ִϸ��̼�
        float newY = Mathf.Sin(Time.time * speed) * (height / 3);
        logoImage.transform.localPosition = startPos + new Vector3(0, newY, 0);
    }
}
