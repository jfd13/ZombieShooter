using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGrenadeThrower_SearchForPlayer : MonoBehaviour
{
    public Transform skeletonGrenadeThrowerTransform; //Skeleton spell caster transform component
    public Transform playerTransform; //player transform component
    public Animator skeletonGrenadeThrowerAnimator; //Skeleton spell caster animator
    public SkeletonGrenadeThrower_Variables skeletonGrenadeThrowerVariablesScript; //Skeleton spell caster variables script
    public SkeletonGrenadeThrower_GrenadeThrowing skeletonGrenadeThrowerGrenadeThrowingScript;

    //-------------------------------------------------------------------------------------------------------------------------------

    float distance; //Float distance to calculate distance later
    float swordThrowDistance; //Float throwing distance, distance which determines if skeleton can already throw or not
    float slapDistance; //Float slap distance
    bool grenadeThrowingBool;
    bool walkTowardsPlayerBool;

    public void Update()
    {
        //Calling method in which I update variables
        Variables();

        //Calling method in which I calculate distance between skeleton and player
        DistanceFromPlayer();

        //Follow player method in which I set the skeleton to follow player or not
        FollowPlayer();
    }

    //-------------------------------------------------------------------------------------------------------------------------------FOLLOW PLAYER OR NOT

    //Method in which I calculate distance between skeleton and player
    public void DistanceFromPlayer()
    {
        distance = Vector3.Distance(playerTransform.position, skeletonGrenadeThrowerTransform.position);
    }



    //Method in which I set the skeleton to follow player
    public void FollowPlayer()
    {
        //If distance is bigger than throwing distance then initiate the statement
        if (distance > swordThrowDistance)
        {
            //Called method for walking animation and enabled it
            WalkingAnimation(true, 1, 0);
        }

        //If distance is smaller than throwing distance and distance is bigger than slap distance then initiate the statement
        else if (distance < swordThrowDistance && distance > slapDistance && grenadeThrowingBool == true && walkTowardsPlayerBool == false)
        {
            //Called method for walking animation and disabled it
            WalkingAnimation(false, 0, 0);
        }

        //If distance is smaller than throwing distance and distance is smaller than slap distance then initiate the statement
        else if (distance < swordThrowDistance && distance < slapDistance && grenadeThrowingBool == true && walkTowardsPlayerBool == false)
        {
            //Called method for walking animation and disabled it
            WalkingAnimation(false, 0, 0);
        }
        else if (grenadeThrowingBool == false && walkTowardsPlayerBool == true)
        {
            //Start walking towards player method
            WalkToPlayer();
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------WALKING ANIMATION CONTROLLER

    //Method for controlling walking animation
    void WalkingAnimation(bool walkingAnimation, float walking_X, float walking_Y)
    {
        skeletonGrenadeThrowerAnimator.SetBool("Walking_Animation", walkingAnimation);
        skeletonGrenadeThrowerAnimator.SetFloat("Walking_X", walking_X);
        skeletonGrenadeThrowerAnimator.SetFloat("Walking_Y", walking_Y);
    }

    public void WalkToPlayer()
    {
        TurnToPlayer();
        WalkingAnimation(true, 1, 0);
    }

    //Turning to player method
    public void TurnToPlayer()
    {
        Vector3 lookPos = playerTransform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
        transform.rotation = rotation;
    }

    //-------------------------------------------------------------------------------------------------------------------------------VARIABLES

    //Calling all variables I need from variables script in which I set all the variables I need
    public void Variables()
    {
        swordThrowDistance = skeletonGrenadeThrowerVariablesScript.grenadeThrowDistance;
        slapDistance = skeletonGrenadeThrowerVariablesScript.slapDistance;
        walkTowardsPlayerBool = skeletonGrenadeThrowerGrenadeThrowingScript.walkTowardsPlayerBool;
        grenadeThrowingBool = skeletonGrenadeThrowerGrenadeThrowingScript.grenadeThrowingBool;
    }
}
