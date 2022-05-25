using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_HitPlayer : MonoBehaviour
{

    public Transform playerTransform; //Transform position of a player
    public Transform skeletonTransform; //Transform position of skeleton
    public Animator skeletonAnimator; //Animator from skeleton
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
        //Call clones components
        skeletonTransformClone = this.GetComponent<Transform>();
        skeletonAnimatorClone = this.GetComponent<Animator>();

        //Call hit player method
        HitPlayer(whichAnimationPlays);
    }

    public void HitPlayer(int whichAnimationPlays)
    {

        //Animation controller method
        void HitPlayerAnimations(bool hit_Animations, float sword_Hit_X, float Sword_Hit_Y)
        {
            skeletonAnimatorClone.SetBool("Hit_Animations", hit_Animations);
            skeletonAnimatorClone.SetFloat("Sword_Hit_X", sword_Hit_X);
            skeletonAnimatorClone.SetFloat("Sword_Hit_Y", Sword_Hit_Y);
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        //Calculate distance between player and skeleton
        distance = Vector3.Distance(playerTransform.position, skeletonTransformClone.position);

        //Draw a line between player and skeleton
        Debug.DrawLine(playerTransform.position, skeletonTransformClone.position, Color.red);



        //If at certain distance, hit player
        if (distance < 2f)
        {
            //If 2 meters away from the player, then play hit animation and hit player
            HitPlayerAnimations(true, whichAnimationPlays, 0);
        }
        else if (distance > 2f)
        {
            //If more than 2 meter away from the player, then turn off hit animation
            skeletonAnimatorClone.SetBool("Hit_Animations", false);
        }
    }
}
