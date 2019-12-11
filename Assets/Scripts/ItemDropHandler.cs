using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public Transform world;

    private GameObject Item;

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform rect = transform as RectTransform;

        if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition))
        {
            Item = ItemDragHandler.itemBeingDragged.gameObject;
            Item.transform.position = Item.GetComponent<ItemDragHandler>().startPosition;
            Item.transform.SetParent(Item.GetComponent<ItemDragHandler>().startParent);
            ItemDragHandler.itemBeingDragged.SetParent(transform);
        }

    }

    //public GameObject Item
    //{
    //    get
    //    {
    //        if (transform.childCount > 0)
    //        {
    //            return transform.GetChild(0).gameObject;
    //        }
    //        return null;
    //    }
    //}

    //public void OnDrop(PointerEventData eventData)
    //{
    //    RectTransform rect = transform as RectTransform;

    //    if (!Item)
    //    {
    //        ItemDragHandler.itemBeingDragged.SetParent(transform);
    //    }
    //    else
    //    {
    //        Item.transform.position = Item.GetComponent<ItemDragHandler>().startPosition;
    //        Item.transform.SetParent(Item.GetComponent<ItemDragHandler>().startParent);
    //        ItemDragHandler.itemBeingDragged.SetParent(transform);
    //    }

    //}
}
