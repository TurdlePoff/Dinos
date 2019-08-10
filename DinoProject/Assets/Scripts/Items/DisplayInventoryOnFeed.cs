using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventoryOnFeed : MonoBehaviour
{
    public int m_iInventoryPosition = 0;

    private bool m_bDisplayCrops = true;
    private int m_iCurrentInventoryOffset = 0;
    

    public void SetCurrentOffSet(int _iOffSet)
    {
        m_iCurrentInventoryOffset = _iOffSet;
    }

    public Image GetCurrentImageToDisplay()
    {
        // Find inventory amount and display at this position
        int iPosition = m_iInventoryPosition + (m_iCurrentInventoryOffset * 8); //8 inventory slots, so offset needs to be adjusted by 8

        //Find image in invenotyr position iPosition

        //if none, return null
        return null;
    }
}
