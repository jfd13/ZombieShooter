using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Rigidbody skeletonRigidbody; //Skeleton rigidbody
    public Transform playerTransform; //Transform component from player
    [HideInInspector] public Transform skeletonFrisbeeThrowerTransformClone; //Transform clone from original
    public SkeletonFrisbeeThrower_Variables skeletonFrisbeeThrowerVariablesScript; //Variabels script from frisbee thrower
    public AudioSource swordOnPlayerHitSound1; //Sound 1
    public AudioSource swordOnPlayerHitSound2; //Sound 2
    [HideInInspector] public AudioSource swordOnPlayerHitSoundClone1; //Sound 1 clone
    [HideInInspector] public AudioSource swordOnPlayerHitSoundClone2; //Sound 2 clone


    float speedOfProjectile; //The speed of projectile
    int sound; //Which sound plays on player hit

    public void Start()
    {
        //Randomize which sound plays on player hit
        sound = Random.Range(1, 3);
    }

    public void Update()
    {
        //Call variables method
        Variables();

        //Call velocity and rotation method
        VelocityAndRotation();
    }

    //Apply velocity and rotation method
    public void VelocityAndRotation()
    {
        //Get the transform component from this object
        skeletonFrisbeeThrowerTransformClone = this.GetComponent<Transform>();

        //Player position, so it throws towards the player
        Vector3 lookPos = playerTransform.position - skeletonFrisbeeThrowerTransformClone.position;
        
        //Apply force towards the player
        this.GetComponent<Rigidbody>().AddForce(lookPos * speedOfProjectile, ForceMode.Impulse);

        //Apply constant rotation
        this.GetComponent<Transform>().Rotate(0, 5, 0);
    }

    //Call variables method
    public void Variables()
    {
        speedOfProjectile = skeletonFrisbeeThrowerVariablesScript.speedOfSwordProjectile;
    }

    //On trigger enter method
    public void OnTriggerEnter(Collider other)
    {
        //If it touched player then do the following
        if (other.gameObject.CompareTag("Player"))
        {
            //Destroy the object
            Destroy(this.gameObject);

            //If sound 1 or 2 has been randomized then go in instantiate sound and play it
            if (sound == 1)
            {
                swordOnPlayerHitSoundClone1 = Instantiate(swordOnPlayerHitSound1, playerTransform.position, playerTransform.rotation);
                swordOnPlayerHitSoundClone1.Play();
            }
            else if (sound == 2)
            {
                swordOnPlayerHitSoundClone2 = Instantiate(swordOnPlayerHitSound2, playerTransform.position, playerTransform.rotation);
                swordOnPlayerHitSoundClone2.Play();
            }
        }

        //If the sword hit the wall destroy it
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
