using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject m_rInventory;
    
    public void SetInventoryActive(Toggle _toggle)
    {
        if (!_toggle)
            return;

        m_rInventory.SetActive(_toggle.isOn);
    }
}
