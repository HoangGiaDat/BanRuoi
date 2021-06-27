using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnFireController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        FireInfor.isFire = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FireInfor.isFire = false;
    }

    
}
