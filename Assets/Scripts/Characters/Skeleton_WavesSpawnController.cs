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
    public TextMeshProUGUI onButtonPressText;
    public GameObject onButtonPressGameObject;



    public int wavesAmount;
    public int currentWave;
    public float timeBetweenWaves;
    public float timer;
    float timeRemaining;
    bool timerIsRunning;
    bool increaseTheSpawnLimitOnce;
    int spawnLimit;
    int invokeSeconds;
    bool veryEasy;
    bool easy;
    bool normal;
    bool hard;
    bool veryHard;
    bool legendary;

    //Modifier very easy, easy, normal, hard, very hard, legendary through buttons

    public void Start()
    {
        SetVariables();
    }

    public void Update()
    {

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
    
    public void OnButtonPressVeryEasy()
    {
        DifficultyVariables(true, false, false, false, false, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("VERY EASY SELECTED");
        Invoke("TurnOffTextAfterButtonPress", invokeSeconds);
    }

    public void OnButtonPressEasy()
    {
        DifficultyVariables(false, true, false, false, false, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("EASY SELECTED");
        Invoke("TurnOffTextAfterButtonPress", invokeSeconds);
    }

    public void OnButtonPressNormal()
    {
        DifficultyVariables(false, false, true, false, false, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("NORMAL SELECTED");
        Invoke("TurnOffTextAfterButtonPress", invokeSeconds);
    }

    public void OnButtonPressHard()
    {
        DifficultyVariables(false, false, false, true, false, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("HARD SELECTED");
        Invoke("TurnOffTextAfterButtonPress", invokeSeconds);
    }

    public void OnButtonPressVeryHard()
    {
        DifficultyVariables(false, false, false, false, true, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("VERY HARD SELECTED");
        Invoke("TurnOffTextAfterButtonPress", invokeSeconds);
    }
    public void OnButtonPressLegendary()
    {
        DifficultyVariables(false, false, false, false, false, true);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("LEGENDARY SELECTED");
        Invoke("TurnOffTextAfterButtonPress", invokeSeconds);
    }

    public void TurnOffTextAfterButtonPress()
    {
        onButtonPressGameObject.SetActive(false);
    }

    public void SetVariables()
    {
        currentWave = wavesAmount;
        timeRemaining = 120;
        invokeSeconds = 4;
        timerIsRunning = true;
        veryEasy = false;
        easy = false;
        normal = false;
        hard = false;
        veryHard = false;
        legendary = false;
    }

    public void DifficultyVariables(bool veryEasy1, bool easy1, bool normal1, bool hard1, bool veryHard1, bool legendary1)
    {
        veryEasy = veryEasy1;
        easy = easy1;
        normal = normal1;
        hard = hard1;
        veryHard = veryHard1;
        legendary = legendary1;
    }
}
