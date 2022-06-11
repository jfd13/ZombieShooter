using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    NavMeshAgent navMeshAgent;
    Animator animator;
    int isWalkingHash;
    bool isChasing=false;
    bool isProvoked = false;
    float distanceToTarget = Mathf.Infinity;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckForTarget();

        HandleWalking();
    }
    void CheckForTarget(){
        distanceToTarget = Vector3.Distance(target.position,transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
            
        }  
    }
    void EngageTarget(){
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget < navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    void AttackTarget(){
        navMeshAgent.isStopped = true;
        isChasing = false;
        Debug.Log("Attacking");
    }
    void ChaseTarget(){
        //Debug.Log("Chasing Player");
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(target.position);
        isChasing = true;
    }
    void HandleWalking(){
        bool isWalking = animator.GetBool(isWalkingHash);
        if (isWalking && !isChasing)
        {
            animator.SetBool(isWalkingHash,false);
        }
        else if (!isWalking && isChasing)
        {
            animator.SetBool(isWalkingHash,true);
        }
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
