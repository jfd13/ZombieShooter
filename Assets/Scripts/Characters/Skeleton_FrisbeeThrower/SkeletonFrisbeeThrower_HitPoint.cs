using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFrisbeeThrower_HitPoint : MonoBehaviour
{
    [HideInInspector] public AudioSource audioSourceClone; //Audio source clone variable
    public AudioSource audioSource; //Main audio source which it clones later
    public Transform playerTransform; //Player transform, position of player
    public AudioClip[] AudioClips = new AudioClip[1]; //List of audio clips of slaping the player
    [HideInInspector] public GameObject skeleton; //Skeleton gameobject


    //-------------------------------------------------------------------------------------------------------------------------------


    [HideInInspector] public int randomNumber; //Randomize number to play random sound
    Vector3 lastHitBoxPosition; //Vector3 position of last hit box position
    Vector3 currentPosition; //Vector3 position of current position
    float velocity; //The velocity of hit point
    float timeRemaining; //The remaining time of timer
    bool timerIsRunning = true; //Is timer runing or not
    bool isSpeedHighEnoughBool; //Is speed high enough bool
    bool isInsideOfPlayer; //Is inside the player or not
    bool didHitHappen; //Did the hit already happen or not

    //-------------------------------------------------------------------------------------------------------------------------------

    public void Start()
    {
        //Call instantiation for audio source method
        Instantiation();

        //Find hitpoints main skeleton parent method
        FindParent();
    }

    public void Update()
    {
        //Random number for played sound
        randomNumber = Random.Range(0, 2);

        //Hit speed method
        HitSpeed();

        //Is speed high enough or not
        isSpeedHighEnough();

        //Is speed high enough timer
        isSpeedHighEnoughTimer();

        //Is inside player or not method
        IsInsideThePlayerOrNot();
    }

    //-------------------------------------------------------------------------------------------------------------------------------ON TRIGGER ENTER/EXIT

    //Check if its inside player
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInsideOfPlayer = true;
        }
    }

    //Check if its outside player
    public void OnTriggerExit(Collider other)
    {
        isInsideOfPlayer = false;
    }

    //-------------------------------------------------------------------------------------------------------------------------------AUDIO METHODS

    //Set the clip of audiosource to random one which was randomized in start method and play it
    public void SetAClipAndPlayASound(int number)
    {
        audioSourceClone.clip = AudioClips[number];
        audioSourceClone.Play();
    }

    //Instantiate audio source so it plays seperately and not on the same time for all skeletons
    public void Instantiation()
    {
        audioSourceClone = Instantiate(audioSource, playerTransform.position, playerTransform.rotation);
    }

    //-------------------------------------------------------------------------------------------------------------------------------VELOCITY CALCULATION METHODS

    //Calculate velocity of hit point method
    public float VelocityCalculation()
    {
        return Mathf.Abs(((currentPosition - lastHitBoxPosition) / Time.deltaTime).magnitude);
    }

    //The speed at which hit point moves
    public void HitSpeed()
    {
        currentPosition = skeleton.transform.position - transform.position;
        VelocityCalculation();
        velocity = VelocityCalculation();
        lastHitBoxPosition = currentPosition;
    }

    //Check if speed is high enough method and apply the parameters
    public void isSpeedHighEnough()
    {
        if (velocity > 15)
        {
            isSpeedHighEnoughBool = true;
            timeRemaining = 0.5f;
            timerIsRunning = true;
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------VELOCITY TIMER

    //Timer to turn off certain bools
    public void isSpeedHighEnoughTimer()
    {
        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                //Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                isSpeedHighEnoughBool = false;
                didHitHappen = false;
            }
        }
    }

    //Display time for timer
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }

    //-------------------------------------------------------------------------------------------------------------------------------HIT PLAYER METHOD

    //Check if its inside the player or not and hit player
    public void IsInsideThePlayerOrNot()
    {
        if (isInsideOfPlayer == true && isSpeedHighEnoughBool == true && didHitHappen == false)
        {
            SetAClipAndPlayASound(randomNumber);
            isSpeedHighEnoughBool = false;
            didHitHappen = true;
            //Hit player
        }
    }


    //-------------------------------------------------------------------------------------------------------------------------------OTHER METHODS


    //Find the parent of this child, main parent skeleton
    private void FindParent()
    {
        skeleton = transform.gameObject;
        while (skeleton.layer != LayerMask.NameToLayer("Skeleton"))
        {
            skeleton = skeleton.transform.parent.gameObject;
        }
    }
}
