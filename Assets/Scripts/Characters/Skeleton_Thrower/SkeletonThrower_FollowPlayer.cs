using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonThrower_FollowPlayer : MonoBehaviour
{

    public Animator skeletonAnimator; //Animator from skeleton
    public Transform playerTransform; //Transform position of a player
    public Transform skeletonTransform; //Transform position of skeleton
    public Rigidbody skeletonRigidbody; //Skeleton rigidbody
    static Animator skeletonAnimatorClone; //Animator component of skeleton clone
    static Transform skeletonTransformClone; //Transform component of skeleton clone
    public SkeletonThrower_HitPlayer skeletonThrowerHitPlayerScript;

    //-------------------------------------------------------------------------------------------------------------------------------

    static float distance; //Distance - used to calculate distance between skeleton and player
    [HideInInspector] public int whichAnimationPlays; //Used to randomize which hit animation plays for specific skeleton
    [HideInInspector] public int maximumThrowingRange;

    //-------------------------------------------------------------------------------------------------------------------------------

    public void Start()
    {
        //Randomize number which is used to determine which animation plays later
        //I have 2 animations in the animator controller, thus playing it randomly on number 1 or number 2
        whichAnimationPlays = 1;

    }

    public void Update()
    {
        maximumThrowingRange = skeletonThrowerHitPlayerScript.maximumDistanceBeforeThrow;

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
        if (distance > maximumThrowingRange)
        {
            //If above 2 meters, walk or run
            WalkingAnimations(true, whichAnimationPlays, 0);
        }
        else if (distance < maximumThrowingRange)
        {
            //If below 2 meters, stop walk/run animation
            skeletonAnimatorClone.SetBool("Walking_Animations", false);
        }
    }
}

