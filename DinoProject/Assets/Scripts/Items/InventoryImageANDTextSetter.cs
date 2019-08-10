using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryImageANDTextSetter : MonoBehaviour, IDropHandler
{
    public int m_iPosition = 0;
    public Image m_rImage;
    public Color m_cDefaultColour;
    public Color m_cActiveColour;

    private ObjectPlacement m_rObjectPlacer;
    private Inventory m_Inventory;
    private int m_iCurrentValue = 0;
    private string m_strCurrentItemName = "NONE";

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Button>().image;
        m_Inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        m_rObjectPlacer = GameObject.FindGameObjectWithTag("ObjectPlacer").GetComponent<ObjectPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_iCurrentValue != m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition))
        {
            if ((m_iCurrentValue == 0 && m_iCurrentValue < m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition)) 
             || (m_iCurrentValue == 1 && m_iCurrentValue > m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition)))
            {
                ChangeValue(); // Went from item image to black image vice verse
            }
            else
            {
                ChangeValue();
            }
            m_iCurrentValue = m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition);
        }

        if(0 < m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition))
        {
            if(m_strCurrentItemName != m_Inventory.GetFirstSeedItemAtPosition(m_iPosition).GetItem().name)
            {
                m_strCurrentItemName = m_Inventory.GetFirstSeedItemAtPosition(m_iPosition).GetItem().name;
                ChangeImage();
            }
        }
        else if("NONE" != m_strCurrentItemName)
        {
            ChangeImage();
            m_strCurrentItemName = "NONE";
        }
    }

    private void ChangeValue()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition).ToString();
    }

    private void ChangeImage()
    {
        if (0 == m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition))
        {
            gameObject.GetComponent<Image>().color = m_cDefaultColour;
            gameObject.GetComponent<Image>().sprite = null;
        }
        else
        {
            gameObject.GetComponent<Image>().color = m_cActiveColour;
            gameObject.GetComponent<Image>().sprite = m_Inventory.GetFirstSeedItemAtPosition(m_iPosition).GetItem().m_2DSprite;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemHarness harness = m_Inventory.GetFirstSeedItemAtPosition(m_iPosition);
        if (!harness)
            return;

        if(m_rObjectPlacer.ObjectRayCastCheck(harness.GetItem().m_3DModel))
        {
            m_Inventory.RemoveFirstSeedItemAtPositon(m_iPosition);
            Debug.Log("Drop Item");
        }
    }
}
