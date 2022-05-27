using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonThrower_AI : MonoBehaviour
{
    public Transform playerTransform;
    static Transform skeletonTransformClone;
    Rigidbody skeletonRigidbody;

    public int maxDistanceCheck;
    bool RaycastForward;
    public float nextTurn;
    float nextTurnToPlayer;

    public void Update()
    {
        skeletonTransformClone = GetComponent<Transform>();

        ObstacleChecking();
        RayCast();

        Debug.Log(RaycastForward);
    }

    public void ObstacleChecking()
    {
        if (RaycastForward == true)
        {
            Debug.Log("Turn right 1");
            TurnRight();
        }
        else if (RaycastForward == false)
        {
            KeepGoingForward();

            if (Time.time > nextTurnToPlayer)
            {
                nextTurnToPlayer = Time.time + nextTurn;
                TurnToPlayer();
            }
        }
    }
    public void TurnToPlayer()
    {
        skeletonTransformClone.LookAt(playerTransform.position, Vector3.up);
    }

    public void TurnRight()
    {
         skeletonTransformClone.Rotate(0, 1 ,0);
    }

    public void TurnLeft()
    {
        skeletonTransformClone.LookAt(-skeletonTransformClone.transform.right);
    }

    public void KeepGoingForward()
    {
        skeletonTransformClone.Rotate(0, 0, 0);
    }

    public void TurnBackwards()
    {
        skeletonTransformClone.LookAt(-skeletonTransformClone.transform.forward);
    }

    public void RayCast()
    {
        RaycastForward = Physics.Raycast(skeletonTransformClone.position, skeletonTransformClone.forward, maxDistanceCheck);
        Debug.DrawRay(skeletonTransformClone.position, skeletonTransformClone.forward, Color.blue);
    }
}


