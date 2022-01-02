using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private Transform[] walkPoints;
    private int m_WalkIndex = 0;

    private Transform m_PlayerTarget;

    private Animator m_Anim;
    private NavMeshAgent m_NavAgent;
    
    private Vector3 m_NextDistance;
    
    [SerializeField] private float _chaseRange = 15f;
    private float distanceToTarget;

    private string PLAYERPARAMETR = "Player";
    private string ATTACKPARAMETR = "attack";

    private void Awake()
    {
        m_PlayerTarget = GameObject.FindWithTag(PLAYERPARAMETR).transform;
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 destination = walkPoints[m_WalkIndex].position;
        m_NavAgent.SetDestination(destination);
        
         distanceToTarget = Vector3.Distance(m_PlayerTarget.position, transform.position);
        
        if (distanceToTarget <= _chaseRange)
        {
            FollowPlayer();
        }
        else
        {
            float remainDistance = Vector3.Distance(transform.position, walkPoints[m_WalkIndex].position);
         
            if (remainDistance <= 3f)
            {
                if (m_WalkIndex == walkPoints.Length - 1)
                {
                    m_WalkIndex = 0;
                }
                else
                {
                    m_WalkIndex++;
                   
                }
            }
        }
    }

    private void FollowPlayer()
    {
        m_NavAgent.SetDestination(m_PlayerTarget.position);
        if (distanceToTarget <= m_NavAgent.stoppingDistance)
        {
            m_Anim.SetBool(ATTACKPARAMETR,true);
        }
        else
        {
            m_Anim.SetBool(ATTACKPARAMETR,false);
        }
    }
    
}
