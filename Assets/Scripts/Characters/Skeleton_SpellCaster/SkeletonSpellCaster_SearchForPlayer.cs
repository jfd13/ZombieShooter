using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpellCaster_SearchForPlayer : MonoBehaviour
{
    public Transform skeletonSpellCasterTransform; //Skeleton spell caster transform component
    public Transform playerTransform; //player transform component
    public Animator skeletonSpellCasterAnimator; //Skeleton spell caster animator
    public SkeletonSpellCaster_Variables skeletonSpellCasterVariablesScript; //Skeleton spell caster variables script
    public SkeletonSpellCaster_SpellCast skeletonSpellCasterSpellCastScript;
    public SkeletonSpellCaster_Slaping skeletonSpellCasterSlapingScript;

    //-------------------------------------------------------------------------------------------------------------------------------

    float distance; //Float distance to calculate distance later
    float spellCastDistance; //Float throwing distance, distance which determines if skeleton can already throw or not
    float slapDistance;
    bool spellCastBool;
    bool walkTowardsPlayerBool;
    bool isSpellCasting;
    bool isSlaping;
    float nextDistanceCheck;
    float distanceCheckRate;

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
        if (Time.time > nextDistanceCheck)
        {
            nextDistanceCheck = Time.time + distanceCheckRate;

            //Calculate distance between player and skeleton
            distance = Vector3.Distance(playerTransform.position, skeletonSpellCasterTransform.position);
        }
    }



    //Method in which I set the skeleton to follow player
    public void FollowPlayer()
    {
        //If distance is bigger than throwing distance then initiate the statement
        if (distance > spellCastDistance && isSpellCasting == false)
        {
            //Called method for walking animation and enabled it
            WalkingAnimation(true, 1, 0);
        }

        //If distance is smaller than throwing distance and distance is bigger than slap distance then initiate the statement
        else if (distance < spellCastDistance && distance > slapDistance && spellCastBool == true && walkTowardsPlayerBool == false)
        {
            //Called method for walking animation and disabled it
            WalkingAnimation(false, 0, 0);
        }

        //If distance is smaller than throwing distance and distance is smaller than slap distance then initiate the statement
        else if (distance < spellCastDistance && distance < slapDistance && spellCastBool == true && walkTowardsPlayerBool == false)
        {
            //Called method for walking animation and disabled it
            WalkingAnimation(false, 0, 0);
        }
        else if (spellCastBool == false && walkTowardsPlayerBool == true && isSpellCasting == false && isSlaping == false)
        {
            WalkToPlayer();
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------WALKING ANIMATION CONTROLLER

    //Method for controlling walking animation
    void WalkingAnimation(bool walkingAnimation, float walking_X, float walking_Y)
    {
        skeletonSpellCasterAnimator.SetBool("Walking_Animation", walkingAnimation);
        skeletonSpellCasterAnimator.SetFloat("Walking_X", walking_X);
        skeletonSpellCasterAnimator.SetFloat("Walking_Y", walking_Y);
    }

    public void WalkToPlayer()
    {
        TurnToPlayer();
        WalkingAnimation(true, 1, 0);
    }

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
        spellCastDistance = skeletonSpellCasterVariablesScript.spellCastDistance;
        slapDistance = skeletonSpellCasterVariablesScript.slapDistance;
        walkTowardsPlayerBool = skeletonSpellCasterSpellCastScript.walkTowardsPlayerBool;
        spellCastBool = skeletonSpellCasterSpellCastScript.spellCastBool;
        isSpellCasting = skeletonSpellCasterSpellCastScript.isSpellCasting;
        isSlaping = skeletonSpellCasterSlapingScript.isSlaping;
        distanceCheckRate = skeletonSpellCasterVariablesScript.distanceCheckRate;
    }
}