using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpellCaster_SpellCast : MonoBehaviour
{
    public Transform skeletonSpellCasterTransform; //Skeleton spell caster transform component
    public Transform playerTransform; //player transform component
    public Animator skeletonSpellCasterAnimator; //Skeleton spell caster animator
    public SkeletonSpellCaster_Variables skeletonSpellCasterVariablesScript; //Skeleton spell caster variables script
    public GameObject lightningGameObject; //Lightning game object
    public GameObject afterburnerGameObject; // Afterburner game object

    //-------------------------------------------------------------------------------------------------------------------------------

    float distance; //Float distance to calculate distance later
    float spellCastDistance; //Float throwing distance, distance which determines if skeleton can already throw or not
    float slapDistance; //Distance in which skeleton slaps the player
    float timeRemaining; //Float of how much time remaining, used in timer
    bool timerIsRunning; //Is timer runing bool
    [HideInInspector] public bool spellCastBool; //Is spell casting method enabled
    bool walkTowardsPlayerBool; //Can skeleton start walking towards player bool
    [HideInInspector] public bool canSkeletonSlap; //Can skeleton slap or not variable
    int spellCastingRandomizer; //Variable for randomizing spellcasting
    public bool canApplyDamage; //Used in other script to determine if it can apply damage or not

    //-------------------------------------------------------------------------------------------------------------------------------UPDATE/START METHOD

    public void Start()
    {
        SetVariables();
    }

    public void Update()
    {
        //Calling method in which I update variables
        Variables();

        //Calling method in which I calculate distance between skeleton and player
        DistanceFromPlayer();

        //Method in which I set the skeleton to spell cast player or not
        CheckDistance();
    }

    //-------------------------------------------------------------------------------------------------------------------------------SPELLCASTING


    //Method in which I calculate distance between skeleton and player
    public void DistanceFromPlayer()
    {
        distance = Vector3.Distance(playerTransform.position, skeletonSpellCasterTransform.position);
    }

    //Method in which I set the skeleton to spell cast player
    public void CheckDistance()
    {
        //If distance is bigger than throwing distance then initiate the statement
        if (distance > spellCastDistance)
        {
            //Disabling the spellcast animation
            SpellCastAnimation(false, 0, 0);
        }

        //If distance is smaller than spell cast distance and distance is bigger than slap distance initiate the statement
        else if (distance <= spellCastDistance && distance > slapDistance)
        {
            //Calling timer method
            Timer();

            //Called randomize spell casting method
            RandomizeSpellCasting();

            //Play casting animation
            if (spellCastBool == true && spellCastingRandomizer == 1)
            {
                //Disabling the walking animation since it interferes with the spell casting animation in the "search for player" script
                WalkingAnimation(false, 0, 0);

                //Disabling the slaping animation, because it interferes with the slaping animation in the slaping script
                SlapingAnimation(false, 0, 0);

                //Enabling the spellcast animation
                SpellCastAnimation(true, 1, 0);

                //Calling coroutine for spell casting
                StartCoroutine(SpellCast());

                //Set skeleton to false so that skeleton switches animation to spell casting instead of staying in slaping
                canSkeletonSlap = false;
            }

            //If spellcasting is disabled and walking towards player enabled
            else if (spellCastBool == false && walkTowardsPlayerBool == true)
            {
                //Turn of spell cast animation
                SpellCastAnimation(false, 0, 0);

                //Start walking towards player method
                WalkToPlayer();
            }
        }

        //If distance is smaller than the spell cast distance and distance is smaller than the slap distance initiate the statement
        else if (distance < spellCastDistance && distance < slapDistance)
        {
            //Stop playing casting animation
            SpellCastAnimation(false, 0, 0);
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------ANIMATION CONTROLLER METHODS


    //Animation controller method for spellcasting
    public void SpellCastAnimation(bool spellCastAnimation, float spellCast_X, float spellCast_Y)
    {
        skeletonSpellCasterAnimator.SetBool("SpellCast_Animation", spellCastAnimation);
        skeletonSpellCasterAnimator.SetFloat("SpellCast_X", spellCast_X);
        skeletonSpellCasterAnimator.SetFloat("SpellCast_Y", spellCast_Y);
    }

    //Method for controlling walking animation
    void WalkingAnimation(bool walkingAnimation, float walking_X, float walking_Y)
    {
        skeletonSpellCasterAnimator.SetBool("Walking_Animation", walkingAnimation);
        skeletonSpellCasterAnimator.SetFloat("Walking_X", walking_X);
        skeletonSpellCasterAnimator.SetFloat("Walking_Y", walking_Y);
    }

    //Method for controlling slaping animation
    void SlapingAnimation(bool slapingAnimation, float slaping_X, float slaping_Y)
    {
        skeletonSpellCasterAnimator.SetBool("Slaping", slapingAnimation);
        skeletonSpellCasterAnimator.SetFloat("Slaping_X", slaping_X);
        skeletonSpellCasterAnimator.SetFloat("Slaping_Y", slaping_Y);
    }

    //-------------------------------------------------------------------------------------------------------------------------------TIMER

    //Timer method
    public void Timer()
    {
        if (timerIsRunning == true)
        {
            //This is counting down the timer
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            //This sets the timer to 10, reseting it and all bools to true/false
            else if (timeRemaining <= 0)
            {
                //Debug.Log("Time has run out!");
                timeRemaining = 10;
                timerIsRunning = true;
                spellCastBool = true;
                walkTowardsPlayerBool = false;
            }
        }
    }

    //Part of timer, displays time on console
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }

    //-------------------------------------------------------------------------------------------------------------------------------RANDOMIZER

    //Makes spell casting random based on number generation
    public void RandomizeSpellCasting()
    {
        spellCastingRandomizer = Random.Range(0, 500);
    }

    //-------------------------------------------------------------------------------------------------------------------------------METHODS

    //Walk to player method when its doing nothing instead of idling tries to go towards the player
    public void WalkToPlayer()
    {
        TurnToPlayer();
        WalkingAnimation(true, 1, 0);
    }

    //Turning to player method
    public void TurnToPlayer()
    {
        Vector3 lookPos = playerTransform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
        transform.rotation = rotation;
    }


    //-------------------------------------------------------------------------------------------------------------------------------IE-NUMERATORS

    //Enables spellcasting
    IEnumerator SpellCast()
    {
        spellCastBool = false;
        yield return new WaitForSeconds(2.6f);
        yield return new WaitForSeconds(0.2f);
        canApplyDamage = true;
        lightningGameObject.SetActive(true);
        afterburnerGameObject.SetActive(true);
        StartCoroutine(SpellCastOff());
    }

    //Disables spellcasting
    IEnumerator SpellCastOff()
    {
        yield return new WaitForSeconds(0.8f);
        lightningGameObject.SetActive(false);
        afterburnerGameObject.SetActive(false);
        canApplyDamage = false;
        walkTowardsPlayerBool = true;
        canSkeletonSlap = true;
    }


    //-------------------------------------------------------------------------------------------------------------------------------VARIABLES

    //Calling all variables I need from variables script in which I set all the variables I need
    public void Variables()
    {
        spellCastDistance = skeletonSpellCasterVariablesScript.spellCastDistance;
        slapDistance = skeletonSpellCasterVariablesScript.slapDistance;
    }

    public void SetVariables()
    {
        //Setting timer on true so it can start runing
        timerIsRunning = true;

        //Setting spellcast bool to true
        spellCastBool = true;

        //Setting walking towards player bool to false
        walkTowardsPlayerBool = false;

        //Can skeleton slap or not set on true so that skeleton can slap in other script
        canSkeletonSlap = true;

        //Setting starting time for timer on 10 seconds (1 is one second, 2 two seconds and so on...)
        timeRemaining = 10;
    }
}
