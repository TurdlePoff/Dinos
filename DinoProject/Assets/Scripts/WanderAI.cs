using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour
{
    public float m_fWanderRadius = 5.0f;
    public float m_fWanderSphereDistance = 7.5f;
    public float m_fDistanceTillAcceptableArrival = 1.0f;
    public Vector2 m_WanderTimer = new Vector2(1.0f, 5.0f);

    private Transform m_target;
    private UnityEngine.AI.NavMeshAgent m_agent;
    private float m_fTimer;
    private Vector3 m_TargetLocation = new Vector3(0.0f, 0.0f, 0.0f);


    private void OnEnable()
    {
        m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_fTimer = Random.Range(m_WanderTimer.x, m_WanderTimer.y);
    }

    // Update is called once per frame
    void Update()
    {
        m_fTimer -= Time.deltaTime;
        if(0 >= m_fTimer || m_fDistanceTillAcceptableArrival > Vector3.Distance(transform.position, m_TargetLocation))
        {
            m_TargetLocation = RandomNavSphere(transform.position, transform.position + transform.forward * m_fWanderSphereDistance, m_fWanderRadius, -1);
            m_agent.SetDestination(m_TargetLocation);
            m_fTimer = Random.Range(m_WanderTimer.x, m_WanderTimer.y);
        }
    }
    public static Vector3 RandomNavSphere(Vector3 _origin, Vector3 _SphereCentreInfront, float _fSphereSize, int _iLayermask)
    {
        Vector3 randDirection = (Random.insideUnitSphere * _fSphereSize) + _SphereCentreInfront;

        UnityEngine.AI.NavMeshHit navHit;

        if(!UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, _fSphereSize, _iLayermask))
        {
            UnityEngine.AI.NavMesh.SamplePosition(new Vector3(0.0f, 0.0f, 0.0f), out navHit, _fSphereSize, _iLayermask);
        }

        return navHit.position;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (transform.forward * m_fWanderSphereDistance), m_fWanderRadius);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(m_TargetLocation, 1.0f);
    }
}
