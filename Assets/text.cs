using Kalkatos.DottedArrow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class text : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int a = 0;
    public void OnBeginDrag(PointerEventData eventData)
    {
        a = 3;
        
    }

    //�巡�� �� ��� ȣ��
    public void OnDrag(PointerEventData eventData)
    {

    }

    //�巡�� ���� �� ȣ��
    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
