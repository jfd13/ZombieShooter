using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpellCaster_Slaping : MonoBehaviour
{
    public Transform skeletonSpellCasterTransform; //Skeleton spell caster transform component
    public Transform playerTransform; //player transform component
    public Animator skeletonSpellCasterAnimator; //Skeleton spell caster animator
    public SkeletonSpellCaster_Variables skeletonSpellCasterVariablesScript; //Skeleton spell caster variables script
    public SkeletonSpellCaster_SpellCast skeletonSpellCasterSpellCastScript; //Skeleton spell caster spellcast script

    //-------------------------------------------------------------------------------------------------------------------------------

    float distance; //Float distance to calculate distance later
    float spellCastDistance; //Float throwing distance, distance which determines if skeleton can already throw or not
    float slapDistance; //Distance in which the skeleton can slap the player
    bool canSkeletonSlap; //Can skeleton slap already or not variable
    [HideInInspector] public bool isSlaping;


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
        distance = Vector3.Distance(playerTransform.position, skeletonSpellCasterTransform.position);
    }



    //Method in which I set the skeleton to slap player or not
    public void SlapPlayer()
    {
        //If distance is bigger than throwing distance then initiate the statement
        if (distance > spellCastDistance)
        {
            //Disable the slaping animation
            SlapingAnimation(false, 0, 0);

            isSlaping = false;
        }

        //If distance is smaller than throwing distance and distance is bigger than slap distance then initiate the statement
        else if (distance < spellCastDistance && distance > slapDistance)
        {
            //Disable the slaping animation
            SlapingAnimation(false, 0, 0);

            isSlaping = false;
        }

        //If distance is smaller than throwing distance and distance is smaller than slap distance and can skeleton slap on true then initiate the statement
        else if (distance < spellCastDistance && distance < slapDistance && canSkeletonSlap == true)
        {
            //Enable the slaping animation
            SlapingAnimation(true, 1, 0);

            //Disable the walking animation
            WalkingAnimation(false, 0, 0);

            isSlaping = true;
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------WALKING ANIMATION CONTROLLER

    //Method for controlling slaping animation
    void SlapingAnimation(bool slapingAnimation, float slaping_X, float slaping_Y)
    {
        skeletonSpellCasterAnimator.SetBool("Slaping", slapingAnimation);
        skeletonSpellCasterAnimator.SetFloat("Slaping_X", slaping_X);
        skeletonSpellCasterAnimator.SetFloat("Slaping_Y", slaping_Y);
    }

    //Method for controlling walking animation
    void WalkingAnimation(bool walkingAnimation, float walking_X, float walking_Y)
    {
        skeletonSpellCasterAnimator.SetBool("Walking_Animation", walkingAnimation);
        skeletonSpellCasterAnimator.SetFloat("Walking_X", walking_X);
        skeletonSpellCasterAnimator.SetFloat("Walking_Y", walking_Y);
    }

    //-------------------------------------------------------------------------------------------------------------------------------VARIABLES

    //Calling all variables I need from variables script in which I set all the variables I need
    public void Variables()
    {
        spellCastDistance = skeletonSpellCasterVariablesScript.spellCastDistance;
        slapDistance = skeletonSpellCasterVariablesScript.slapDistance;

        //Calling can skeleton slap from another script to prevent shooting when slaping
        canSkeletonSlap = skeletonSpellCasterSpellCastScript.canSkeletonSlap;
    }
}
