using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectPlacement : MonoBehaviour
{
    private CustomGrid m_grid;
    public Image m_rMessage;

    private TextMeshProUGUI m_rMsgText;
    public GameObject[] m_rObjectsToPlace;

    void Awake()
    {
        m_grid = FindObjectOfType<CustomGrid>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        m_rMsgText = m_rMessage.GetComponentInChildren<TextMeshProUGUI>();
        m_rMessage.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        m_rMsgText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
    }


    public bool ObjectRayCastCheck(GameObject m_item)
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            //Checktype
            //----------
            //Check if item is blocking
            if (!hitInfo.collider.CompareTag("Produce"))
            {
                PlaceObject(m_item, hitInfo.point);
                return true;
            }
            else
            {
                m_rMessage.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
                m_rMsgText.GetComponent<CanvasRenderer>().SetAlpha(1.0f);

                m_rMessage.CrossFadeAlpha(0.0f, 1.5f, true);
                m_rMsgText.CrossFadeAlpha(0.0f, 1.5f, true);
            }
        }
        return false;
    }


    private void PlaceObject(GameObject m_item, Vector3 _selectedPos)
    {
        Vector3 finalPos = m_grid.GetNearestPointOnGrid(_selectedPos);
        //Instantiate(m_rObjectsToPlace[0], finalPos, Quaternion.identity);
        Instantiate(m_item, finalPos, Quaternion.identity);
    }
}
