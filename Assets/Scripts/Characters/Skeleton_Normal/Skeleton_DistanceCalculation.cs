using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_DistanceCalculation : MonoBehaviour
{

    public Transform playerTransform; //Transform position of a player
    static Animator skeletonAnimatorClone; //Animator component of skeleton clone
    static Transform skeletonTransformClone; //Transform component of skeleton clone

    //-------------------------------------------------------------------------------------------------------------------------------

    static float distance; //Distance - used to calculate distance between skeleton and player
    [HideInInspector] public int whichAnimationPlays; //Used to randomize which hit animation plays for specific skeleton

    //-------------------------------------------------------------------------------------------------------------------------------

    public void Start()
    {
        //Randomize number which is used to determine which animation plays later
        //I have 2 animations in the animator controller, thus playing it randomly on number 1 or number 2
        whichAnimationPlays = Random.Range(1, 2);

    }

    public void Update()
    {
        //Call components from a clone
        skeletonTransformClone = this.GetComponent<Transform>();
        skeletonAnimatorClone = this.GetComponent<Animator>();

        //Call follow player method
        FollowPlayer(whichAnimationPlays);
    }

    //-------------------------------------------------------------------------------------------------------------------------------

    public void FollowPlayer(int whichAnimationPlays)
    {

        //Animation controller method
        void WalkingAnimations(bool walkingAnimations, float walking_X, float walking_Y)
        {
            skeletonAnimatorClone.SetBool("Walking_Animations", walkingAnimations);
            skeletonAnimatorClone.SetFloat("Walking_X", walking_X);
            skeletonAnimatorClone.SetFloat("Walking_Y", walking_Y);
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        //Calculate distance between player and skeleton
        distance = Vector3.Distance(playerTransform.position, skeletonTransformClone.position);

        //If at certain distance play walk animation
        if (distance > 2f)
        {
            //If above 2 meters, walk or run
            WalkingAnimations(true, whichAnimationPlays, 0);
        }
        else if (distance < 2f)
        {
            //If below 2 meters, stop walk/run animation
            skeletonAnimatorClone.SetBool("Walking_Animations", false);
        }
    }
}
