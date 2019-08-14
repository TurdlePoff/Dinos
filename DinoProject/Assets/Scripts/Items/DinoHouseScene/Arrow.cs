using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool m_bRightArrow = false;

    private int m_iCurrentOffSet = 0;
    private int m_iMaxScrollTimes = 1;
    private List<DisplayInventoryOnFeed> m_DisplayInventory = new List<DisplayInventoryOnFeed>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allInventory = GameObject.FindGameObjectsWithTag("ProduceFeedDisplay");
        foreach(GameObject item in allInventory)
        {
            if(item.GetComponent<DisplayInventoryOnFeed>())
            {
                m_DisplayInventory.Add(item.GetComponent<DisplayInventoryOnFeed>());
            }
        }

        foreach(DisplayInventoryOnFeed item in m_DisplayInventory)
        {
            item.SetCurrentOffSet(m_iCurrentOffSet);
            item.ResetCurrentImageToDisplay();
        }

        m_iMaxScrollTimes = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().GetTotalNumberOfProduce() % 8;
        Scroll(); //Set Current Values that are in the inventory
    }

    public void Scroll()
    {
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

        foreach (DisplayInventoryOnFeed item in m_DisplayInventory)
        {
            item.SetCurrentOffSet(m_iCurrentOffSet);
            item.ResetCurrentImageToDisplay();
        }

        print(m_iCurrentOffSet);
    }
}
