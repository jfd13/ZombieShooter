using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonThrower_HitPlayer : MonoBehaviour
{

    public Transform playerTransform; //Transform position of a player
    public Transform skeletonTransform; //Transform position of skeleton
    public Animator skeletonAnimator; //Animator from skeleton
    public Rigidbody skeletonRigidbody; //Skeleton rigidbody
    static Animator skeletonAnimatorClone; //Animator component of skeleton clone
    static Transform skeletonTransformClone; //Transform component of skeleton clone

    //-------------------------------------------------------------------------------------------------------------------------------

    static float distance; //Distance - used to calculate distance between skeleton and player
    [HideInInspector] public int whichAnimationPlays; //Used to randomize which hit animation plays for specific skeleton
    public int maximumDistanceBeforeThrow;
    float nextThrow;
    public float throwingHitRate;
    public int minimumSkeletonThrowingSpawnRate;
    public int maximumSkeletonThrowingSpawnRate;
    //-------------------------------------------------------------------------------------------------------------------------------

    public void Start()
    {
        //Randomize number which is used to determine which animation plays later
        whichAnimationPlays = Random.Range(0, 3);
    }

    public void Update()
    {
        //Call clones components
        skeletonTransformClone = this.GetComponent<Transform>();
        skeletonAnimatorClone = this.GetComponent<Animator>();

        //Call hit player method
        HitPlayer(whichAnimationPlays);
    }

    //-------------------------------------------------------------------------------------------------------------------------------

    public void HitPlayer(int whichAnimationPlays)
    {

        //-------------------------------------------------------------------------------------------------------------------------------

        //Calculate distance between player and skeleton
        distance = Vector3.Distance(playerTransform.position, skeletonTransformClone.position);

        //Draw a line between player and skeleton
        Debug.DrawLine(playerTransform.position, skeletonTransformClone.position, Color.red);



        //If at certain distance, throw at player
        if (distance < maximumDistanceBeforeThrow)
        {
            ThrowRandomChance();
        }
        else if (distance > maximumDistanceBeforeThrow)
        {
            //If more than 2 meter away from the player, then turn off hit animation
            skeletonAnimatorClone.SetBool("Throw_Animations", false);
        }
    }

    public void ThrowRandomChance()
    {

        if (Time.time > nextThrow)
        {
            nextThrow = Time.time + throwingHitRate;
            throwingHitRate = Random.Range(minimumSkeletonThrowingSpawnRate, maximumSkeletonThrowingSpawnRate);
            ThrowPlayerAnimations(true, whichAnimationPlays, 0);

            if (whichAnimationPlays == 0)
            {
                //Instantiate missile
                //Start coroutine in seconds
                //Disable the animation through coroutine
            }
            else if (whichAnimationPlays == 1)
            {
                //Instantiate missile
                //Start coroutine in seconds
                //Disable the animation through coroutine
            }
            else if (whichAnimationPlays == 2)
            {
                //Instantiate missile
                //Start coroutine in seconds
                //Disable the animation through coroutine
            }
        }
    }

    //Animation controller method
    public void ThrowPlayerAnimations(bool throw_Animations, float Throw_Hit_X, float Throw_Hit_Y)
    {
        skeletonAnimatorClone.SetBool("Throw_Animations", throw_Animations);
        skeletonAnimatorClone.SetFloat("Throw_Hit_X", Throw_Hit_X);
        skeletonAnimatorClone.SetFloat("Throw_Hit_Y", Throw_Hit_Y);
    }
}
