using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpellCaster_LightningHitPoint : MonoBehaviour
{
    public SkeletonSpellCaster_SpellCast skeletonSpellCasterSpellCastScript; //Script spell cast from which I take a variable
    public SkeletonSpellCaster_Variables skeletonSpellCasterVariablesScript; //Script variables in which I store variables
    [HideInInspector] public GameObject skeleton; //Game object skeleton to find main skeleton
    public AudioSource lightningOnHit; //Hurt sound on player hit with lightning


    bool canApplyDamage; //Can it apply damage yet, take from spell cast script
    float nextLightningHit; //Calculating time from last hit
    float lightningHitRate; //Lightning hit rate edited in variables script

    public void Start()
    {
        //Call find parent method
        FindParent();
    }

    public void Update()
    {
        //Call variables method
        Variables();
        
        //Call applydamage method
        ApplyDamage();
    }

    //I apply damage in this method
    public void ApplyDamage()
    {
        //Check with raycast if it hit the player
        Physics.Raycast(skeleton.transform.position, skeleton.transform.forward, out RaycastHit hitInfo, 5);

        //If can apply damage is true, time is bigger than the calculated time and raycast hit player then go into this if statement
        if (canApplyDamage == true && Time.time > nextLightningHit && hitInfo.collider.CompareTag("Player"))
        {
            //Calculate time
            nextLightningHit = Time.time + lightningHitRate;

            //Play hurt sound
            lightningOnHit.Play();

            //Apply damage (for the future)
        }
    }

    //Find parent of this object method
    public void FindParent()
    {
        skeleton = transform.gameObject;
        while (skeleton.layer != LayerMask.NameToLayer("Skeleton"))
        {
            skeleton = skeleton.transform.parent.gameObject;
        }
    }


    //Call variables from other scripts
    public void Variables()
    {
        lightningHitRate = skeletonSpellCasterVariablesScript.lightningHitRate;
        canApplyDamage = skeletonSpellCasterSpellCastScript.canApplyDamage;
    }
}
