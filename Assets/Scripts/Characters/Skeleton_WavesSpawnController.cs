using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skeleton_WavesSpawnController : MonoBehaviour
{
    public GameObject skeletonNormal;
    public GameObject skeletonFrisbeeThrower;
    public GameObject skeletonSpellCaster;
    public GameObject skeletonGrenadeThrower;
    public List<GameObject> Spawners = new List<GameObject>();
    public TextMeshProUGUI veryEasyButton;
    public TextMeshProUGUI easyButton;
    public TextMeshProUGUI normalButton;
    public TextMeshProUGUI hardButton;
    public TextMeshProUGUI veryHardButton;
    public TextMeshProUGUI legendaryButton;



    public int wavesAmount;
    public int currentWave;
    public float timeBetweenWaves;
    public float timer;
    float timeRemaining = 120;
    bool timerIsRunning;
    bool increaseTheSpawnLimitOnce;
    int spawnLimit;
    bool veryEasy;
    bool easy;
    bool normal;
    bool hard;
    bool veryHard;
    bool legendary;

    //Modifier very easy, easy, normal, hard, very hard, legendary through buttons

    public void Start()
    {
        currentWave = wavesAmount;
        timerIsRunning = true;
    }


    public void SpawnNormalSkeletons()
    {
        if (timeRemaining > 0 && veryEasy == true)
        {
            
        }
        else if (timeRemaining > 0 && easy == true)
        {

        }
        else if (timeRemaining > 0 && normal == true)
        {

        }
        else if (timeRemaining > 0 && hard == true)
        {

        }
        else if (timeRemaining > 0 && veryHard == true)
        {

        }
        else if (timeRemaining > 0 && legendary == true)
        {

        }
    }

    public void Difficulty()
    {

    }


    public void Timer()
    {
        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else if (timeRemaining <= 0)
            {
                Debug.Log("End of the wave");
                timeRemaining = 0;
                timerIsRunning = false;

                if (increaseTheSpawnLimitOnce == true)
                {
                    spawnLimit = spawnLimit++;
                    increaseTheSpawnLimitOnce = false;
                }
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }
}
