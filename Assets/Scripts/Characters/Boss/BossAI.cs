using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float attackRange = 2f;
    NavMeshAgent navMeshAgent;
    Animator animator;
    int isWalkingHash;
    bool isChasing=false;
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
        if (distanceToTarget < chaseRange && distanceToTarget > attackRange)
        {
            //Debug.Log("Chasing Player");
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(target.position);
            isChasing = true;
        }  
        else if (distanceToTarget < attackRange)
        {
            navMeshAgent.isStopped = true;
            isChasing = false;
        }
        else
        {
            isChasing = false;
        }
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
