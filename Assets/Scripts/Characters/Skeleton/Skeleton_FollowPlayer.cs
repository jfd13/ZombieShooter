using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_FollowPlayer : MonoBehaviour
{
    //Forward +, Backwards - | FROM SKELETON POSITION
    //Right +, Left - | FROM SKELETON POSITION

    public Animator skeletonAnimator; //Animator from skeleton
    public Transform playerTransform; //Transform position of a player
    public Transform skeletonTransform; //Transform position of skeleton
    public Rigidbody skeletonRigidbody; //Skeleton rigidbody
    public Skeleton_SpawnController skeletonSpawnControllerScript; //Skeleton SpawnController script
    static Animator skeletonAnimatorClone; //Animator component of skeleton clone
    static Transform skeletonTransformClone; //Transform component of skeleton clone

    //-------------------------------------------------------------------------------------------------------------------------------

    static float distance; //Distance - used to calculate distance between skeleton and player
    static int whichAnimationPlays; //Used to randomize which hit animation plays for specific skeleton

    //-------------------------------------------------------------------------------------------------------------------------------

    public void Start()
    {
        //Randomize number which is used to determine which animation plays later
        whichAnimationPlays = Random.Range(1, 3);
    }

    public void Update()
    {
        //Call components from a clone
        skeletonAnimatorClone = this.GetComponent<Animator>();
        skeletonTransformClone = this.GetComponent<Transform>();

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
            WalkingAnimations(false, 0, 0);
        }
    }
}