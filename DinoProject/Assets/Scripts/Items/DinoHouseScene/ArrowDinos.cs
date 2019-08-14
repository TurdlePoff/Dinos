using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDinos : MonoBehaviour
{
    public bool m_bRightArrow = false;

    private int m_iCurrentOffSet = 0;
    private int m_iMaxScrollTimes = 1;
    private List<DisplayInventoryOnDinos> m_DisplayInventory = new List<DisplayInventoryOnDinos>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allInventory = GameObject.FindGameObjectsWithTag("DinoFeedDisplay");
        foreach(GameObject item in allInventory)
        {
            if(item.GetComponent<DisplayInventoryOnDinos>())
            {
                m_DisplayInventory.Add(item.GetComponent<DisplayInventoryOnDinos>());
            }
        }

        foreach(DisplayInventoryOnDinos item in m_DisplayInventory)
        {
            item.SetCurrentOffSet(m_iCurrentOffSet);
            item.ResetCurrentImageToDisplay();
        }

        m_iMaxScrollTimes = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().GetTotalNumberOfDinos() / 8;
        Scroll(); //Set Current Values that are in the inventory
    }

    public void Scroll()
    {
        m_iMaxScrollTimes = (int)Mathf.Ceil(GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().GetTotalNumberOfDinos() / 8); //Delete this later? or move to location where it doesn't effect
        m_iMaxScrollTimes += 1;
        print("Current maxScroll: " + m_iMaxScrollTimes);

        if (!m_bRightArrow)
        {
            m_iCurrentOffSet -= 1;
            if (0 > m_iCurrentOffSet)
            {
                m_iCurrentOffSet = m_iMaxScrollTimes;
            }
        }
        else
        {
            m_iCurrentOffSet += 1;
        }

        if (0 < m_iMaxScrollTimes)
        {
            m_iCurrentOffSet %= m_iMaxScrollTimes;
        }
        else
        {
            m_iCurrentOffSet = 0;
        }

        print("Current OffSet: " + m_iCurrentOffSet);

        foreach (DisplayInventoryOnDinos item in m_DisplayInventory)
        {
            item.SetCurrentOffSet(m_iCurrentOffSet);
            item.ResetCurrentImageToDisplay();
        }

        print(m_iCurrentOffSet);
    }
}
