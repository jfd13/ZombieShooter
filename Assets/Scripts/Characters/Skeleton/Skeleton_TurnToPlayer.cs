using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_TurnToPlayer : MonoBehaviour
{
    public Transform lookTarget; //The target which skeleton will follow
    public Transform lookTargetLeft;
    public Transform lookTargetBack;
    public Transform lookTargetRight;
    public Transform skeletonTransform; //Transform position of skeleton
    static Transform skeletonTransformClone; //Transform component of skeleton clone
    public NavMeshAgent skeletonNavMeshAgent;
    public Transform playerTransform;
    [HideInInspector] public Rigidbody skeletonRigidbodyClone;


    public int SkeletonCheckingDistance;
    bool RayRight;
    bool RayLeft;
    bool RayBackwards;
    bool RayForward;
    float nextTurn1;
    float nextTurn2;
    float nextTurn3;
    float nextTurn4;
    public float Turnrate1;
    public float Turnrate2;
    public float Turnrate3;
    public float Turnrate4;
    bool Turn;
    public Vector3 skeletonMovement;

    //-------------------------------------------------------------------------------------------------------------------------------

    public void Start()
    {
        skeletonTransformClone = this.GetComponent<Transform>();
        skeletonRigidbodyClone = skeletonTransformClone.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        skeletonTransformClone = this.GetComponent<Transform>();
        skeletonRigidbodyClone = skeletonTransformClone.GetComponent<Rigidbody>();

        //Call turning to player method
        AiBehaviour();
    }

    //-------------------------------------------------------------------------------------------------------------------------------

    public void AiBehaviour()
    {

        skeletonNavMeshAgent.SetDestination(playerTransform.position);

    }

    public void TurnToPlayer()
    {
        skeletonTransformClone.LookAt(lookTarget, Vector3.up);
    }



    public void TurnLeft()
    {
        skeletonTransformClone.LookAt(-skeletonTransformClone.right, Vector3.up);
    }



    public void TurnRight()
    {
        skeletonTransformClone.LookAt(skeletonTransformClone.right, Vector3.up);
    }



    public void TurnBack()
    {
        skeletonTransformClone.LookAt(-skeletonTransformClone.forward, Vector3.up);
    }

    public void TurnForward()
    {
        skeletonTransformClone.LookAt(skeletonTransformClone.forward, Vector3.up);
    }

    public void RayCasting()
    {
        Debug.DrawRay(skeletonTransformClone.position, skeletonTransformClone.right, Color.blue);
        Debug.DrawRay(skeletonTransformClone.position, -skeletonTransformClone.right, Color.blue);
        Debug.DrawRay(skeletonTransformClone.position, skeletonTransformClone.forward, Color.blue);
        Debug.DrawRay(skeletonTransformClone.position, -skeletonTransformClone.forward, Color.blue);


        RayRight = Physics.Raycast(skeletonTransformClone.position, skeletonTransformClone.right, SkeletonCheckingDistance);
        RayLeft = Physics.Raycast(skeletonTransformClone.position, -skeletonTransformClone.right, SkeletonCheckingDistance);
        RayForward = Physics.Raycast(skeletonTransformClone.position, skeletonTransformClone.forward, SkeletonCheckingDistance);
        RayBackwards = RayRight = Physics.Raycast(skeletonTransformClone.position, -skeletonTransformClone.forward, SkeletonCheckingDistance);
    }
}
