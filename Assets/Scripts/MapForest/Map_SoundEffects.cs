using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_SoundEffects : MonoBehaviour
{
    public AudioSource childWhispering; //Call audio source child whispering
    public AudioSource wind; //Call audio source wind
    public AudioSource monsterScreaming; //Call audio source monster screaming
    public ParticleSystem dustSmoke;
    public GameObject dustSmokeGameObject;

    //----------------------------------------------------------------------------------------------------------------------------------------------

    int randomSound; //Randomize which sound plays
    bool randomizeOnce; //Randomize only once so it doesnt constantly repeat
    float timeRemaining; // Remaining time before randomization
    bool timerIsRunning; //Is timer runing or not
    bool playSoundOnce; //Play sound only once so it doesnt play multiple times
    public float timeOfSoundPlay; //Seconds before sound can be played

    //----------------------------------------------------------------------------------------------------------------------------------------------

    public void Start()
    {
        //Call set variables method
        SetVariables();
    }

    public void Update()
    {
        //Call timer method
        Timer();
    }

    //-------------------------------------------------------------------------------------------------------------------------------------RANDOMIZE AND PLAY SOUND

    //Randomize only once which sound plays
    public void Randomize()
    {
        if (randomizeOnce == true)
        {
            randomSound = Random.Range(0, 16);
            randomizeOnce = false;
        }
    }

    //Play sound if the random number is equal to the given one in if statement
    public void PlaySound()
    {
        if (randomSound == 1 && playSoundOnce == true)
        {
            childWhispering.Play();
            playSoundOnce = false;
        }
        else if (randomSound == 2 && playSoundOnce == true)
        {
            wind.Play();
            dustSmoke.Play();
            dustSmokeGameObject.SetActive(true);
            StartCoroutine(WindTimer());
            playSoundOnce = false;
        }
        else if (randomSound == 3 && playSoundOnce == true)
        {
            monsterScreaming.Play();
            playSoundOnce = false;
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------TIMERS

    //Timer before it randomizes and plays the sound if the number is correct
    public void Timer()
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
                Debug.Log("Time has run out!");
                timeRemaining = timeOfSoundPlay;
                Randomize();
                PlaySound();
                timerIsRunning = true;
                randomizeOnce = true;
                playSoundOnce = true;
            }
        }
    }

    //Display time method
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }

    IEnumerator WindTimer()
    {
        yield return new WaitForSeconds(50);
        dustSmokeGameObject.SetActive(false);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------SET VARIABLES

    //Set variables at start
    public void SetVariables()
    {
        timerIsRunning = true;
        randomizeOnce = true;
        playSoundOnce = true;
        timeRemaining = timeOfSoundPlay;
    }
}
