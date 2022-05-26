using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_AI : MonoBehaviour
{
    public NavMeshAgent skeletonNavMeshAgent;
    public Transform playerTransform;

    public void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        skeletonNavMeshAgent.SetDestination(playerTransform.position);
    }
}
