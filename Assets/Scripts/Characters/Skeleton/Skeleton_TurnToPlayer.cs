using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_TurnToPlayer : MonoBehaviour
{
    public Transform lookTarget; //The target which skeleton will follow
    public Transform skeletonTransform; //Transform position of skeleton

    //-------------------------------------------------------------------------------------------------------------------------------

    public void Update()
    {
        //Call turning to player method
        TurnToPlayer();
    }

    //-------------------------------------------------------------------------------------------------------------------------------

    public void TurnToPlayer()
    {
        //Constantly turning to player position, basically turning towards a point that is set on the player
        skeletonTransform.LookAt(lookTarget, Vector3.up);
    }
}
