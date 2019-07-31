using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public float m_fTarget = 100.0f;
    public Transform m_Target;

    void Start()
    {
        
    }

    void Update()
    {
        if(m_Target)
        {
            transform.RotateAround(m_Target.position, m_Target.up, m_fTarget * Time.deltaTime);
        }
    }
}
