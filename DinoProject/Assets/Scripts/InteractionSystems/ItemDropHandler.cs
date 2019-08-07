using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    private ObjectPlacement m_rObjectPlacer;

    private void Start()
    {
        m_rObjectPlacer = GameObject.FindGameObjectWithTag("ObjectPlacer").GetComponent<ObjectPlacement>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform inventoryPanel = (RectTransform)transform;
        if(!RectTransformUtility.RectangleContainsScreenPoint(inventoryPanel, Input.mousePosition))
        {
            Debug.Log("Drop Item");
            //m_rObjectPlacer.ObjectRayCastCheck();
        }
    }
}
