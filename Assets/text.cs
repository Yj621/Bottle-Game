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

    //드래그 중 계속 호출
    public void OnDrag(PointerEventData eventData)
    {

    }

    //드래그 끝날 때 호출
    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
