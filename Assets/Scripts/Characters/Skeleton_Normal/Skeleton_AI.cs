using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_AI : MonoBehaviour
{
    public NavMeshAgent skeletonNavMeshAgent;
    public Transform playerTransform;
    static Transform skeletonTransformClone; //Transform component of skeleton clone

    static float distance; //Distance - used to calculate distance between skeleton and player

    public void Update()
    {
        skeletonTransformClone = this.GetComponent<Transform>();

        FollowPlayer();
    }

    public void FollowPlayer()
    {
        skeletonNavMeshAgent.SetDestination(playerTransform.position);

        //-------------------------------------------------------------------------------------------------------------------------------

        //Calculate distance between player and skeleton
        distance = Vector3.Distance(playerTransform.position, skeletonTransformClone.position);

        //If at certain distance set speed to some number
        if (distance > 2f)
        {
            //If above 2 meters, run
            skeletonNavMeshAgent.speed = 5;
        }
        else if (distance < 2f)
        {
            //If below 2 meters, stop runing
            skeletonNavMeshAgent.speed = 0;
        }
    }


}
