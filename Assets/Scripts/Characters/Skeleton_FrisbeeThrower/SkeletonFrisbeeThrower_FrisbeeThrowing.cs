using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFrisbeeThrower_FrisbeeThrowing : MonoBehaviour
{
    public Transform skeletonFrisbeeThrowerTransform; //Skeleton spell caster transform component
    public Transform playerTransform; //player transform component
    public Animator skeletonFrisbeeThrowerAnimator; //Skeleton spell caster animator
    public SkeletonFrisbeeThrower_Variables skeletonFrisbeeThrowerVariablesScript; //Skeleton spell caster variables script
    public GameObject swordGameObject; //Sword game object for instantiating later
    [HideInInspector] public GameObject swordGameObjectClone; //Sword game object clone, used to equate instantiation
    public List<GameObject> swordClones = new List<GameObject>();
    public Vector3 swordOffset;

    //-------------------------------------------------------------------------------------------------------------------------------

    float distance; //Float distance to calculate distance later
    float frisbeeThrowingDistance; //Float throwing distance, distance which determines if skeleton can already throw or not
    float slapDistance; //Distance in which skeleton slaps the player
    float timeRemaining; //Float of how much time remaining, used in timer
    bool timerIsRunning; //Is timer runing bool
    [HideInInspector] public bool frisbeeThrowingBool; //Is spell casting method enabled
    bool walkTowardsPlayerBool; //Can skeleton start walking towards player bool
    [HideInInspector] public bool canSkeletonSlap; //Can skeleton slap or not variable
    int frisbeeThrowingRandomizer; //Variable for randomizing spellcasting
    bool canSkeletonTurnToPlayer; //Can skeleton turn to player bool, used to determine if the skeleton can turn to throw at 90 degrees angle

    //-------------------------------------------------------------------------------------------------------------------------------UPDATE/START METHOD

    public void Start()
    {
        //Setting timer on true so it can start runing
        timerIsRunning = true;

        //Setting spellcast bool to true
        frisbeeThrowingBool = true;

        //Setting walking towards player bool to false
        walkTowardsPlayerBool = false;

        //Can skeleton slap or not set on true so that skeleton can slap in other script
        canSkeletonSlap = true;

        canSkeletonTurnToPlayer = false;

        //Setting starting time for timer on 10 seconds (1 is one second, 2 two seconds and so on...)
        timeRemaining = 10;
    }

    public void Update()
    {
        //Calling method in which I update variables
        Variables();

        //Calling method in which I calculate distance between skeleton and player
        DistanceFromPlayer();

        //Method for calling if skeleton can turn or not while frisbee throwing
        CanSkeletonTurnToPlayer();

        //Method in which I set the skeleton to spell cast player or not
        CheckDistance();
    }

    //-------------------------------------------------------------------------------------------------------------------------------SPELLCASTING


    //Method in which I calculate distance between skeleton and player
    public void DistanceFromPlayer()
    {
        distance = Vector3.Distance(playerTransform.position, skeletonFrisbeeThrowerTransform.position);
    }

    //Method in which I set the skeleton to spell cast player
    public void CheckDistance()
    {
        //If distance is bigger than throwing distance then initiate the statement
        if (distance > frisbeeThrowingDistance)
        {
            //Disabling the spellcast animation
            FrisbeeThrowingAnimation(false, 0, 0);
        }

        //If distance is smaller than spell cast distance and distance is bigger than slap distance initiate the statement
        else if (distance <= frisbeeThrowingDistance && distance > slapDistance)
        {
            //Calling timer method
            Timer();

            //Called randomize spell casting method
            RandomizeSpellCasting();

            //Play casting animation
            if (frisbeeThrowingBool == true && frisbeeThrowingRandomizer == 1)
            {
                //Disabling the walking animation since it interferes with the spell casting animation in the "search for player" script
                WalkingAnimation(false, 0, 0);

                //Disabling the slaping animation, because it interferes with the slaping animation in the slaping script
                SlapingAnimation(false, 0, 0);

                //Enabling the spellcast animation
                FrisbeeThrowingAnimation(true, 1, 0);

                //Calling coroutine for spell casting
                StartCoroutine(FrisbeThrowing());

                //Set skeleton to false so that skeleton switches animation to spell casting instead of staying in slaping
                canSkeletonSlap = false;
            }

            //If spellcasting is disabled and walking towards player enabled
            else if (frisbeeThrowingBool == false && walkTowardsPlayerBool == true)
            {
                //Turn of spell cast animation
                FrisbeeThrowingAnimation(false, 0, 0);

                //Start walking towards player method
                WalkToPlayer();
            }
        }

        //If distance is smaller than the spell cast distance and distance is smaller than the slap distance initiate the statement
        else if (distance < frisbeeThrowingDistance && distance < slapDistance)
        {
            //Stop playing casting animation
            FrisbeeThrowingAnimation(false, 0, 0);
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------ANIMATION CONTROLLER METHODS


    //Animation controller method for spellcasting
    public void FrisbeeThrowingAnimation(bool frisbeeThrowingAnimation, float frisbeeThrowing_X, float frisbeeThrowing_Y)
    {
        skeletonFrisbeeThrowerAnimator.SetBool("FrisbeeThrow_Animation", frisbeeThrowingAnimation);
        skeletonFrisbeeThrowerAnimator.SetFloat("FrisbeeThrow_X", frisbeeThrowing_X);
        skeletonFrisbeeThrowerAnimator.SetFloat("FrisbeeThrow_Y", frisbeeThrowing_Y);
    }

    //Method for controlling walking animation
    void WalkingAnimation(bool walkingAnimation, float walking_X, float walking_Y)
    {
        skeletonFrisbeeThrowerAnimator.SetBool("Walking_Animation", walkingAnimation);
        skeletonFrisbeeThrowerAnimator.SetFloat("Walking_X", walking_X);
        skeletonFrisbeeThrowerAnimator.SetFloat("Walking_Y", walking_Y);
    }

    //Method for controlling slaping animation
    void SlapingAnimation(bool slapingAnimation, float slaping_X, float slaping_Y)
    {
        skeletonFrisbeeThrowerAnimator.SetBool("Slaping", slapingAnimation);
        skeletonFrisbeeThrowerAnimator.SetFloat("Slaping_X", slaping_X);
        skeletonFrisbeeThrowerAnimator.SetFloat("Slaping_Y", slaping_Y);
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
                Debug.Log("Time has run out!");
                timeRemaining = 10;
                timerIsRunning = true;
                frisbeeThrowingBool = true;
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
        Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }

    //-------------------------------------------------------------------------------------------------------------------------------RANDOMIZER

    //Makes spell casting random based on number generation
    public void RandomizeSpellCasting()
    {
        frisbeeThrowingRandomizer = Random.Range(0, 500);
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

    //Turn to player when throwing, offset by 90 degrees so that skeleton throws at the player
    public void TurnToPlayerWhenThrowing()
    {
        Debug.Log("Inside turn to player");
        Vector3 lookPos = playerTransform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY - 90, 0);
        transform.rotation = rotation;
    }

    public void CanSkeletonTurnToPlayer()
    {
        if (canSkeletonTurnToPlayer == true)
        {
            TurnToPlayerWhenThrowing();
        }
    }

    public void SwordInstantiation()
    {
        swordGameObjectClone = Instantiate(swordGameObject, skeletonFrisbeeThrowerTransform.position + swordOffset, skeletonFrisbeeThrowerTransform.rotation);
        ListSwordClone();
        Destroy(swordGameObjectClone, 3f);
    }

    public void ListSwordClone()
    {
        for (int i = 0; i < 1; i++)
        {
            swordClones.Add(swordGameObjectClone);
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------IE-NUMERATORS

    //Enables spellcasting
    IEnumerator FrisbeThrowing()
    {
        frisbeeThrowingBool = false;
        canSkeletonTurnToPlayer = true;
        yield return new WaitForSeconds(1.4f);
        SwordInstantiation();
        StartCoroutine(FrisbeThrowingOff());
    }

    //Disables spellcasting
    IEnumerator FrisbeThrowingOff()
    {
        yield return new WaitForSeconds(2f);
        canSkeletonTurnToPlayer = false;
        walkTowardsPlayerBool = true;
        canSkeletonSlap = true;
    }

    //-------------------------------------------------------------------------------------------------------------------------------VARIABLES

    //Calling all variables I need from variables script in which I set all the variables I need
    public void Variables()
    {
        frisbeeThrowingDistance = skeletonFrisbeeThrowerVariablesScript.swordThrowDistance;
        slapDistance = skeletonFrisbeeThrowerVariablesScript.slapDistance;
    }
}
