using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryImageANDTextSetter : MonoBehaviour
{
    public int m_iPosition = 0;
    public Sprite m_DefaultImage;

    private Inventory m_Inventory;
    private int m_iCurrentValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Button>().image;
        m_Inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_iCurrentValue != m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition))
        {
            if ((m_iCurrentValue == 0 && m_iCurrentValue < m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition)) || (m_iCurrentValue == 1 && m_iCurrentValue > m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition)))
            {
                ChangeValue(true); // Went from item image to black image vice verse
            }
            else
            {
                ChangeValue(false);
            }
            m_iCurrentValue = m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition);
        }
    }

    public void ChangeValue(bool _bChangeImage)
    {
        if(_bChangeImage)
        {
            //gameObject.GetComponent<Button>().image = ;
        }
        gameObject.GetComponentInChildren<Text>().text = m_Inventory.GetNumberOfSeedItemsAtPosition(m_iPosition).ToString();
    }
}
