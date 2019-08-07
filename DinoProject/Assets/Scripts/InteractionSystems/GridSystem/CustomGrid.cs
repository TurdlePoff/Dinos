using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    [SerializeField] private float m_fDistBetweenPoints = 1.0f;
    [SerializeField] private int m_iGridSize = 50;
    [SerializeField] private Color m_cColor = Color.yellow;

    public Vector3 GetNearestPointOnGrid(Vector3 _pos)
    {
        //Handle offset before calculating
        _pos -= transform.position;

        //Calculate position on grid
        int xCount = Mathf.RoundToInt(_pos.x / m_fDistBetweenPoints);
        int yCount = Mathf.RoundToInt(_pos.y / m_fDistBetweenPoints);
        int zCount = Mathf.RoundToInt(_pos.z / m_fDistBetweenPoints);

        Vector3 result = new Vector3(
            xCount * m_fDistBetweenPoints,
            yCount * m_fDistBetweenPoints,
            zCount * m_fDistBetweenPoints);

        //Add back offset after calculating
        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = m_cColor;
        for(float x = transform.position.x; x < transform.position.x + m_iGridSize; x += m_fDistBetweenPoints)
        {
            for(float z = transform.position.z; z < transform.position.z + m_iGridSize; z += m_fDistBetweenPoints)
            {
                Vector3 point = GetNearestPointOnGrid(new Vector3(x, 0.0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}
