using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGrenadeThrower_ObstacleChecking : MonoBehaviour
{
    public Transform playerTransform; //Get the player transform component
    static Transform skeletonTransformClone; //Get the skeletons transform component later
    public SkeletonGrenadeThrower_Variables skeletonGrenadeThrowerVariablesScript;

    //-------------------------------------------------------------------------------------------------------------------------------

    int maxDistanceCheck; //Maximum distance of skeletons raycasting length
    bool RaycastForward; //Bool to later equate with raycast pointing forward
    bool RaycastLeft; //Bool to later equate with raycast pointing left
    bool RaycastRight; //Bool to later equate with raycast pointing right
    bool RaycastBackwards; //Bool to later equate with raycast pointing backwards

    //-------------------------------------------------------------------------------------------------------------------------------UPDATE METHOD

    public void Update()
    {
        //Get the component transform from current skeleton
        skeletonTransformClone = GetComponent<Transform>();

        //Calling method which checks for obsticles
        ObstacleChecking();

        //Calling variables method
        Variables();
    }

    //-------------------------------------------------------------------------------------------------------------------------------OBSTACLE CHECKING METHOD

    public void ObstacleChecking()
    {
        //Raycast bools equated with proper raycasts
        RaycastForward = Physics.Raycast(skeletonTransformClone.position, skeletonTransformClone.forward, out RaycastHit RayHitForward, maxDistanceCheck);
        RaycastRight = Physics.Raycast(skeletonTransformClone.position, -skeletonTransformClone.right, out RaycastHit RayHitRight, maxDistanceCheck);
        RaycastLeft = Physics.Raycast(skeletonTransformClone.position, skeletonTransformClone.right, out RaycastHit RayHitLeft, maxDistanceCheck);
        RaycastBackwards = Physics.Raycast(skeletonTransformClone.position, skeletonTransformClone.right, out RaycastHit RayHitBackwards, maxDistanceCheck);

        Debug.DrawRay(skeletonTransformClone.position, skeletonTransformClone.forward, Color.blue);

        //If forward raycast is detecting then do the following
        if (RaycastForward == true)
        {
            TurnRight();
        }
        //If left raycast is detecting then do the following
        else if (RaycastLeft == true)
        {
            //Keep going forward
            KeepGoingForward();
        }
        //If right raycast is detecting then do the following
        else if (RaycastRight == true)
        {
            //Keep going forward
            KeepGoingForward();
        }
        //If right and forward raycast is detecting then do the following
        else if (RaycastRight == true && RaycastForward == true)
        {
            //Turn left
            TurnLeft();
        }
        //If left and forward raycast is detecting then do the following
        else if (RaycastLeft == true && RaycastForward == true)
        {
            //Turn right
            TurnRight();
        }
        //If no raycast is detecting then do the following
        else if (RaycastForward == false && RaycastRight == false && RaycastLeft == false && RaycastBackwards == false)
        {
            //Turn to player
            TurnToPlayer();
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------TURNING METHODS

    //Turn to player method
    public void TurnToPlayer()
    {
        //Look at the player
        Vector3 lookPos = playerTransform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
        transform.rotation = rotation;
    }

    //Turn right method
    public void TurnRight()
    {
        //Rotate right at the speed of 1
        skeletonTransformClone.Rotate(0, 1, 0);
    }

    //Turn left method
    public void TurnLeft()
    {
        //Rotate right at the speed of -1
        skeletonTransformClone.Rotate(0, -1, 0);
    }

    //Going forward method
    public void KeepGoingForward()
    {
        //Do not rotate, go forward
        skeletonTransformClone.Rotate(0, 0, 0);
    }

    //Calling method for variables
    public void Variables()
    {
        //Calling variable Ray max distance check which is checking obsticles inside that distance
        maxDistanceCheck = skeletonGrenadeThrowerVariablesScript.ObstacleDistanceCheck;
    }
}
