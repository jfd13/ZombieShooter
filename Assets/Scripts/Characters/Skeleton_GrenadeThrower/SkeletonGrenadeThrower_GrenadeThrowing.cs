using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGrenadeThrower_GrenadeThrowing : MonoBehaviour
{
    public Transform skeletonGrenadeThrowerTransform; //Skeleton spell caster transform component
    public Transform playerTransform; //player transform component
    public Animator skeletonGrenadeThrowerAnimator; //Skeleton spell caster animator
    public SkeletonGrenadeThrower_Variables skeletonGrenadeThrowerVariablesScript; //Skeleton spell caster variables script
    public GameObject grenadeGameObject; //Sword game object for instantiating later
    [HideInInspector] public GameObject grenadeGameObjectClone; //Sword game object clone, used to equate instantiation
    public List<GameObject> grenadeClones = new List<GameObject>();
    public Vector3 grenadeOffset;

    //-------------------------------------------------------------------------------------------------------------------------------

    float distance; //Float distance to calculate distance later
    float grenadeThrowingDistance; //Float throwing distance, distance which determines if skeleton can already throw or not
    float slapDistance; //Distance in which skeleton slaps the player
    float timeRemaining; //Float of how much time remaining, used in timer
    bool timerIsRunning; //Is timer runing bool
    [HideInInspector] public bool grenadeThrowingBool; //Is spell casting method enabled
    [HideInInspector] public bool walkTowardsPlayerBool; //Can skeleton start walking towards player bool
    [HideInInspector] public bool canSkeletonSlap; //Can skeleton slap or not variable
    int grenadeThrowingRandomizer; //Variable for randomizing spellcasting
    bool canSkeletonTurnToPlayer; //Can skeleton turn to player bool, used to determine if the skeleton can turn to throw at 90 degrees angle
    float timeOfGrenadeExplosion;
    bool isTimerOn;

    //-------------------------------------------------------------------------------------------------------------------------------UPDATE/START METHOD

    public void Start()
    {
        //Setting timer on true so it can start runing
        timerIsRunning = true;

        //Setting spellcast bool to true
        grenadeThrowingBool = true;

        //Setting walking towards player bool to false
        walkTowardsPlayerBool = false;

        //Can skeleton slap or not set on true so that skeleton can slap in other script
        canSkeletonSlap = true;

        canSkeletonTurnToPlayer = false;

        //Setting starting time for timer on 10 seconds (1 is one second, 2 two seconds and so on...)
        timeRemaining = 20;
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
        distance = Vector3.Distance(playerTransform.position, skeletonGrenadeThrowerTransform.position);
    }

    //Method in which I set the skeleton to spell cast player
    public void CheckDistance()
    {
        //If distance is bigger than throwing distance then initiate the statement
        if (distance > grenadeThrowingDistance)
        {
            //Disabling the spellcast animation
            GrenadeThrowingAnimation(false, 0, 0);
        }

        //If distance is smaller than spell cast distance and distance is bigger than slap distance initiate the statement
        else if (distance <= grenadeThrowingDistance && distance > slapDistance)
        {
            //Calling timer method
            Timer();

            //Called randomize spell casting method
            RandomizeGrenadeThrowing();

            //Play casting animation
            if (grenadeThrowingBool == true && grenadeThrowingRandomizer == 1 && isTimerOn == true)
            {
                //Disabling the walking animation since it interferes with the spell casting animation in the "search for player" script
                WalkingAnimation(false, 0, 0);

                //Disabling the slaping animation, because it interferes with the slaping animation in the slaping script
                SlapingAnimation(false, 0, 0);

                //Enabling the spellcast animation
                GrenadeThrowingAnimation(true, 1, 0);

                //Calling coroutine for spell casting
                StartCoroutine(GrenadeThrowing());

                //Set skeleton to false so that skeleton switches animation to spell casting instead of staying in slaping
                canSkeletonSlap = false;
            }

            //If spellcasting is disabled and walking towards player enabled
            else if (grenadeThrowingBool == false && walkTowardsPlayerBool == true)
            {
                //Turn of spell cast animation
                GrenadeThrowingAnimation(false, 0, 0);

                //Start walking towards player method
                WalkToPlayer();
            }
        }

        //If distance is smaller than the spell cast distance and distance is smaller than the slap distance initiate the statement
        else if (distance < grenadeThrowingDistance && distance < slapDistance)
        {
            //Stop playing casting animation
            GrenadeThrowingAnimation(false, 0, 0);
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------ANIMATION CONTROLLER METHODS


    //Animation controller method for spellcasting
    public void GrenadeThrowingAnimation(bool frisbeeThrowingAnimation, float frisbeeThrowing_X, float frisbeeThrowing_Y)
    {
        skeletonGrenadeThrowerAnimator.SetBool("GrenadeThrow_Animation", frisbeeThrowingAnimation);
        skeletonGrenadeThrowerAnimator.SetFloat("GrenadeThrow_X", frisbeeThrowing_X);
        skeletonGrenadeThrowerAnimator.SetFloat("GrenadeThrow_Y", frisbeeThrowing_Y);
    }

    //Method for controlling walking animation
    void WalkingAnimation(bool walkingAnimation, float walking_X, float walking_Y)
    {
        skeletonGrenadeThrowerAnimator.SetBool("Walking_Animation", walkingAnimation);
        skeletonGrenadeThrowerAnimator.SetFloat("Walking_X", walking_X);
        skeletonGrenadeThrowerAnimator.SetFloat("Walking_Y", walking_Y);
    }

    //Method for controlling slaping animation
    void SlapingAnimation(bool slapingAnimation, float slaping_X, float slaping_Y)
    {
        skeletonGrenadeThrowerAnimator.SetBool("Slaping", slapingAnimation);
        skeletonGrenadeThrowerAnimator.SetFloat("Slaping_X", slaping_X);
        skeletonGrenadeThrowerAnimator.SetFloat("Slaping_Y", slaping_Y);
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
                isTimerOn = true;
            }
            //This sets the timer to 10, reseting it and all bools to true/false
            else if (timeRemaining <= 0)
            {
                Debug.Log("Time has run out!");
                timeRemaining = 20;
                isTimerOn = false;
                timerIsRunning = true;
                grenadeThrowingBool = true;
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
    public void RandomizeGrenadeThrowing()
    {
        grenadeThrowingRandomizer = Random.Range(0, 1000);
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
        Vector3 lookPos = playerTransform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY + 30, 0);
        transform.rotation = rotation;
    }

    //Can skeleton turn to player or not, if its throwing no, if it isnt then yes
    public void CanSkeletonTurnToPlayer()
    {
        if (canSkeletonTurnToPlayer == true)
        {
            TurnToPlayerWhenThrowing();
        }
    }

    //Instantiate grenade, list it and destroy it after some time
    public void GrenadeInstantiation()
    {
        grenadeGameObjectClone = Instantiate(grenadeGameObject, skeletonGrenadeThrowerTransform.position + grenadeOffset, skeletonGrenadeThrowerTransform.rotation);
        ListGrenadeClone();
        Destroy(grenadeGameObjectClone, timeOfGrenadeExplosion + 0.2f);
    }

    //Method for making a list
    public void ListGrenadeClone()
    {
        for (int i = 0; i < 1; i++)
        {
            grenadeClones.Add(grenadeGameObjectClone);
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------IE-NUMERATORS

    //Enables spellcasting
    IEnumerator GrenadeThrowing()
    {
        grenadeThrowingBool = false;
        canSkeletonTurnToPlayer = true;
        yield return new WaitForSeconds(3.4f);
        GrenadeInstantiation();
        StartCoroutine(GrenadeThrowingOff());
    }

    //Disables spellcasting
    IEnumerator GrenadeThrowingOff()
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
        grenadeThrowingDistance = skeletonGrenadeThrowerVariablesScript.grenadeThrowDistance;
        slapDistance = skeletonGrenadeThrowerVariablesScript.slapDistance;
        timeOfGrenadeExplosion = skeletonGrenadeThrowerVariablesScript.timeOfGrenadeExplosion;
    }
}
