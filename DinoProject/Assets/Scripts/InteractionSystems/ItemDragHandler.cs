using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public bool m_bTop = false;
    public bool m_bRight = false;

    private Vector3 m_OffsetPosition;
    private Vector3 m_OriginalPosition;

    void Start()
    {
        m_OriginalPosition = transform.position;

        Vector2 uiSize = GetComponent<RectTransform>().rect.size;
        m_OffsetPosition = new Vector3();
        if (m_bTop)
        {
            m_OffsetPosition.y = (uiSize.y / 2.0f);
        }
        else
        {
            m_OffsetPosition.y = -(uiSize.y / 2.0f);
        }
        if (m_bRight)
        {
            m_OffsetPosition.x = (uiSize.x / 2.0f);
        }
        else
        {
            m_OffsetPosition.x = -(uiSize.x / 2.0f);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.SetSiblingIndex(-1);
        transform.position = Input.mousePosition + m_OffsetPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = m_OriginalPosition;
    }
}