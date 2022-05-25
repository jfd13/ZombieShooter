using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Dodge : MonoBehaviour
{
    public Transform playerTransform; //Transform position of a player
    public Transform skeletonTransform; //Transform position of skeleton
    public Animator skeletonAnimator; //Animator component from skeleton
    public Rigidbody skeletonRigidbody; //Skeleton rigidbody
    public Skeleton_SpawnController skeletonSpawnControllerScript; //Defining spawn controller script
    static Transform skeletonTransformClone; //Transform component from skeleton clone used to equate with its component


    static float distance; //Distance - used to calculate distance between skeleton and player
    static int dodgeChance; //Dodge chance, if this is 1 then play dodge animation
    public int maxDodgeChance; //lowest chance is 0, higher is this intiger. Used to randomly calculate dodge chance

    public void Update()
    {
        //Call transform component from a clone
        skeletonTransformClone = this.GetComponent<Transform>();

        //Call Dodge method
        Dodge();
    }

    public void Dodge()
    {
        //Calculate the chance to dodge with a random.range generator
        dodgeChance = Random.Range(0, maxDodgeChance);

        //Calculate distance between player and skeleton
        distance = Vector3.Distance(skeletonTransformClone.position, playerTransform.position);

        

        //If dodgeChance is equal to 1 then play dodge animation and start a timer which then turns it off after fixed amount of time
        if (dodgeChance == 1)
        {
            if (distance > 5f)
            {
                //Start coroutine to turn off the dodge animation
                StartCoroutine(DodgeIsFalseTimer());
                Animations(false, 0, 0, false, 0, 0, true);
            }

        }
    }

    IEnumerator DodgeIsFalseTimer()
    {
        //Wait 1.7 seconds and turn off animation
        yield return new WaitForSeconds(1.7f);
        skeletonAnimator.SetBool("Dodge", false);
    }


    //Animation controller method
    void Animations(bool hit_Animations, float sword_Hit_X, float Sword_Hit_Y, bool walkingAnimations, float walking_X, float walking_Y, bool dodge)
    {
        //Define animations inhere, to use them above
        skeletonAnimator.SetBool("Hit_Animations", hit_Animations);
        skeletonAnimator.SetFloat("Sword_Hit_X", sword_Hit_X);
        skeletonAnimator.SetFloat("Sword_Hit_Y", Sword_Hit_Y);
        skeletonAnimator.SetBool("Walking_Animations", walkingAnimations);
        skeletonAnimator.SetFloat("Walking_X", walking_X);
        skeletonAnimator.SetFloat("Walking_Y", walking_Y);
        skeletonAnimator.SetBool("Dodge", dodge);
    }
}
