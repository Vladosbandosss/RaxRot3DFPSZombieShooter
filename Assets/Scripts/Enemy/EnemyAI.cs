using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
  
  [SerializeField] private float _chaseRange = 5f;
  
  private Transform target;
  private NavMeshAgent _navMeshAgent;
  
  private float distanceToTarget;

  private bool isProvoked;

  private Animator _animator;

  private float turnSpeed =5f;

  private EnemyHealth healh;
  private CapsuleCollider _zombieCollider;
  
  private void Awake()
  {
    target = GameObject.FindWithTag("Player").transform;
    _navMeshAgent = GetComponent<NavMeshAgent>();
    _animator = GetComponent<Animator>();
    healh = GetComponent<EnemyHealth>();
  }

  private void Update()
  {
    if (healh.IsDead())
    {
      enabled = false;
      _navMeshAgent.enabled = false;
        //      _zombieCollider.gameObject.SetActive(false);
    }
    distanceToTarget = Vector3.Distance(target.position, transform.position);
    
    if (isProvoked)
    {
      EngageTarget();//обнаружили игрока
      
    }else if (distanceToTarget <= _chaseRange)
    {
      isProvoked = true;
      
      //_navMeshAgent.SetDestination(target.position);
    }
    
   
  }

  private void EngageTarget()
  {
    FaceTarget();
    
    if (distanceToTarget>_navMeshAgent.stoppingDistance)
    {//стоп дист 1 поставил
      ChaseTarget();//преследуем
    }

    if (distanceToTarget<=_navMeshAgent.stoppingDistance)
    {
      AttackTarget();//атакуем
     
    }
    
  }

  private void ChaseTarget()
  {
    _animator.SetBool("attack",false);
    _animator.SetTrigger("move");
    _navMeshAgent.SetDestination(target.position);
  }

  private void AttackTarget()
  {
  
    _animator.SetBool("attack",true);
  }

  private void FaceTarget()
  {
    Vector3 direction = (target.position - transform.position).normalized;
    Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
    transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*turnSpeed);
  }

  public void OnDamageTaken()
  {
    isProvoked = true;
  }
  
  private void OnDrawGizmos()
  {
    Gizmos.color=Color.red;
    Gizmos.DrawWireSphere(transform.position, _chaseRange);
  }
}
