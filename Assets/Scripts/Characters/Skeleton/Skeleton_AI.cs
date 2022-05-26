using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_AI : MonoBehaviour
{
    public NavMeshAgent skeletonNavMeshAgent;
    public Transform playerTransform;
    public Skeleton_FollowPlayer skeletonFollowPlayerScript;

    public float walkingSpeed;

    public void Start()
    {
        MaximumAllowedSpeedIfWalking();
    }

    public void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        skeletonNavMeshAgent.SetDestination(playerTransform.position);
    }

    public void MaximumAllowedSpeedIfWalking()
    {
        if (skeletonFollowPlayerScript.whichAnimationPlays == 2)
        {
            skeletonNavMeshAgent.speed = walkingSpeed;
        }
    }
}
