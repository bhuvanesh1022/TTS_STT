using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Transform itemBeingDragged;
    public Vector3 startPosition;
    public Transform startParent;
    private CanvasGroup canvasGroup;


    public void Start()
    {
        startPosition = transform.localPosition;
        startParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = transform;

        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        //RectTransform rectTransform = slot.transform as RectTransform;
        //if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
        //{

        //    transform.parent = startParent;
        //}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == startParent)
        {
            transform.localPosition = startPosition;
        }
        else
        {
            transform.localPosition = Vector3.zero;
            if (!GetComponent<PhoneticManager>())
            {
                Instantiate(gameObject, startPosition, Quaternion.identity, startParent);
            }

        }

        itemBeingDragged = null;
    }

}
