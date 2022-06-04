using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFrisbeeThrower_Slaping : MonoBehaviour
{
    public Transform skeletonFrisbeeThrowerTransform; //Skeleton spell caster transform component
    public Transform playerTransform; //player transform component
    public Animator skeletonFrisbeeThrowerAnimator; //Skeleton spell caster animator
    public SkeletonFrisbeeThrower_Variables skeletonFrisbeeThrowerVariablesScript; //Skeleton spell caster spellcast script
    public SkeletonFrisbeeThrower_FrisbeeThrowing skeletonFrisbeeThrowerFrisbeeThrowingScript; //Skeleton frisbee throwing script

    //-------------------------------------------------------------------------------------------------------------------------------

    float distance; //Float distance to calculate distance later
    float frisbeeThrowDistance; //Float throwing distance, distance which determines if skeleton can already throw or not
    float slapDistance; //Distance in which the skeleton can slap the player
    bool canSkeletonSlap; //Can skeleton slap already or not variable

    //-------------------------------------------------------------------------------------------------------------------------------

    public void Update()
    {
        //Calling variables method
        Variables();

        //Calling method for distance between skeleton and player
        DistanceFromPlayer();

        //Calling slap player method
        SlapPlayer();
    }


    //-------------------------------------------------------------------------------------------------------------------------------SLAP PLAYER OR NOT

    //Method in which I calculate distance between skeleton and player
    public void DistanceFromPlayer()
    {
        distance = Vector3.Distance(playerTransform.position, skeletonFrisbeeThrowerTransform.position);
    }



    //Method in which I set the skeleton to slap player or not
    public void SlapPlayer()
    {
        //If distance is bigger than throwing distance then initiate the statement
        if (distance > frisbeeThrowDistance)
        {
            //Disable the slaping animation
            SlapingAnimation(false, 0, 0);
        }

        //If distance is smaller than throwing distance and distance is bigger than slap distance then initiate the statement
        else if (distance < frisbeeThrowDistance && distance > slapDistance)
        {
            //Disable the slaping animation
            SlapingAnimation(false, 0, 0);
        }

        //If distance is smaller than throwing distance and distance is smaller than slap distance and can skeleton slap on true then initiate the statement
        else if (distance < frisbeeThrowDistance && distance < slapDistance && canSkeletonSlap == true)
        {
            //Enable the slaping animation
            SlapingAnimation(true, 1, 0);

            //Disable the walking animation
            WalkingAnimation(false, 0, 0);
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------WALKING ANIMATION CONTROLLER

    //Method for controlling slaping animation
    void SlapingAnimation(bool slapingAnimation, float slaping_X, float slaping_Y)
    {
        skeletonFrisbeeThrowerAnimator.SetBool("Slaping", slapingAnimation);
        skeletonFrisbeeThrowerAnimator.SetFloat("Slaping_X", slaping_X);
        skeletonFrisbeeThrowerAnimator.SetFloat("Slaping_Y", slaping_Y);
    }

    //Method for controlling walking animation
    void WalkingAnimation(bool walkingAnimation, float walking_X, float walking_Y)
    {
        skeletonFrisbeeThrowerAnimator.SetBool("Walking_Animation", walkingAnimation);
        skeletonFrisbeeThrowerAnimator.SetFloat("Walking_X", walking_X);
        skeletonFrisbeeThrowerAnimator.SetFloat("Walking_Y", walking_Y);
    }

    //-------------------------------------------------------------------------------------------------------------------------------VARIABLES

    //Calling all variables I need from variables script in which I set all the variables I need
    public void Variables()
    {
        frisbeeThrowDistance = skeletonFrisbeeThrowerVariablesScript.swordThrowDistance;
        slapDistance = skeletonFrisbeeThrowerVariablesScript.slapDistance;

        //Calling can skeleton slap from another script to prevent shooting when slaping
        canSkeletonSlap = skeletonFrisbeeThrowerFrisbeeThrowingScript.canSkeletonSlap;
    }
}
