using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventoryOnDinos : MonoBehaviour
{
    public Color m_cActiveColour;
    public Color m_cDefaultColour;
    public int m_iInventoryPosition = 0;

    private bool m_bDisplayCrops = true;
    private int m_iCurrentInventoryOffset = 0;
    private Inventory m_Inventory;
    

    public void SetCurrentOffSet(int _iOffSet)
    {
        m_iCurrentInventoryOffset = _iOffSet;
        m_Inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void ResetCurrentImageToDisplay()
    {
        // Find inventory amount and display at this position
        int iPosition = m_iInventoryPosition + (m_iCurrentInventoryOffset * 8); //8 inventory slots, so offset needs to be adjusted by 8

        gameObject.GetComponent<Image>().color = m_cDefaultColour;
        gameObject.GetComponent<Image>().sprite = null;

        //Find image in invenotyr position iPosition
        if(!m_Inventory)
        {
            return;
        }

        if (0 < m_Inventory.GetNumberOfDinosAtPosition(iPosition))
        {
            gameObject.GetComponent<Image>().color = m_cActiveColour;
            gameObject.GetComponent<Image>().sprite = m_Inventory.GetFirstDinoAtPosition(iPosition).GetItem().m_2DSprite;
        }
        return;
    }
}
