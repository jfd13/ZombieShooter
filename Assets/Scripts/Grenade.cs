using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Transform playerTransform; //Transform variable of player
    public Transform skeletonGrenadeThrowerTransformClone; //Trnasform variable of grenade thrower skeleton
    [HideInInspector] public Rigidbody grenadeRigidbody; //Rigidbody component of this grenade
    [HideInInspector] public Transform grenadeTransform; //Transform component of this grenade
    public Collider[] collidersInExplosionRadius; //Colliders in explosion radius
    public SkeletonGrenadeThrower_Variables skeletonGrenadeThrowerVariablesScript; //Variables script of grenade thrower
    public AudioClip explodeSound; //Audio clip, sound of explosion
    public AudioSource explosionAudioSource; //Audio source of grenade explosion
    [HideInInspector] public AudioSource explosionAudioSourceClone; //Clone of audio source original
    public ParticleSystem explosionParticleSystem; //Particle system of explosion
    [HideInInspector] public ParticleSystem explosionParticleSystemClone; //Clone of particle system explosion original


    bool isSoundPlayed; //Did the sound of explosion already play
    bool grenadeApplyForce; //The force of grenade explosion
    bool isExplosionPlayed; //Is explosion particle system already played
    float currentTime; //Grenade explosion timer
    float speedOfProjectile; //Speed of grenade projectile at throw
    float timeOfGrenadeExplosion; //Time before grenade explodes
    float radiusOfExplosion; //Radius of grenade explosion
    float explosionForce; //Explosion force of grenade
    float upwardForceOnExplosion; //Upward force on explosion


    public void Start()
    {
        //Call variables method
        Variables();

        //Set the time to the max time of grenade explosion
        currentTime = timeOfGrenadeExplosion;

        //Get components from this script, rigidbody and transform
        grenadeRigidbody = this.GetComponent<Rigidbody>();
        grenadeTransform = this.GetComponent<Transform>();

        //Apply force on the objects in explosion radius
        grenadeApplyForce = true;
    }

    public void Update()
    {
        //Call variables method
        Variables();

        //Apply velocity of grenade at spawn method
        Velocity();

        //Start the grenade explosion timer
        GrenadeExplosionTimer();
    }

    //Velocity applying method
    public void Velocity()
    {
        //If force was not applied yet go in if statement
        if (grenadeApplyForce == true)
        {
            //Apply force towards player position
            Vector3 lookPos = playerTransform.position - grenadeRigidbody.position;

            //Add force to the rigidbody of grenade
            grenadeRigidbody.AddForce(lookPos * speedOfProjectile, ForceMode.Impulse);

            //Do not apply force 2 times bool, turn it off
            grenadeApplyForce = false;
        }
    }

    //Explosion timer method
    public void GrenadeExplosionTimer()
    {
        //If current time is bigger than 0 go in if statement and substract time.deltatime from current time
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }

        //Else if current time is below or the same as 0 explode
        else if (currentTime <= 0)
        {
            Explode();
        }
    }


    //Explosion method
    public void Explode()
    {
        //Play sound on explosion
        PlaySound();

        //Instantiate particle effect of explosion
        ParticleEffectOnExplosion();

        //In the sphere of explosion later apply force to the objects
        collidersInExplosionRadius = Physics.OverlapSphere(grenadeTransform.position, radiusOfExplosion);

        //For each explosion in the radius apply force
        foreach (var explosion in collidersInExplosionRadius)
        {
            if (explosion.attachedRigidbody == null)
            {
                continue;
            }
            else if (explosion.attachedRigidbody != null)
            {
                explosion.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, grenadeTransform.position, radiusOfExplosion, upwardForceOnExplosion, ForceMode.Impulse);
            }
        }
    }

    //Play sound method
    public void PlaySound()
    {
        //If sound wasnt played yet go in if statement
        if (isSoundPlayed == false)
        {
            //Instantiate new audio source, set the clip to explode sound and play the sound and set bool to false so it doesnt repeat
            explosionAudioSourceClone = Instantiate(explosionAudioSource, grenadeTransform.position, grenadeTransform.rotation);
            explosionAudioSourceClone.clip = explodeSound;
            explosionAudioSourceClone.Play();
            isSoundPlayed = true;
        }
    }

    //Particle effect on explosion method
    public void ParticleEffectOnExplosion()
    {
        //Instantiate particle explosion and play it then turn on bool so it doesnt spawn again
        if (isExplosionPlayed == false)
        {
            explosionParticleSystemClone = Instantiate(explosionParticleSystem, grenadeTransform.position, grenadeTransform.rotation);
            explosionParticleSystemClone.Play();
            isExplosionPlayed = true;
        }
    }

    //Call variables from other scripts method
    public void Variables()
    {
        speedOfProjectile = skeletonGrenadeThrowerVariablesScript.speedOfGrenadeProjectile;
        timeOfGrenadeExplosion = skeletonGrenadeThrowerVariablesScript.timeOfGrenadeExplosion;
        radiusOfExplosion = skeletonGrenadeThrowerVariablesScript.radiusOfGrenadeExplosion;
        explosionForce = skeletonGrenadeThrowerVariablesScript.explosionForceOfGrenade;
        upwardForceOnExplosion = skeletonGrenadeThrowerVariablesScript.upwardForceOnGrenadeExplosion;
    }
}
