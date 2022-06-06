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
    public Transform spawnerTransform;



    public int wavesAmount;
    public int currentWave;
    public float timeBetweenWaves;
    public float timer;

    float spawnRate;
    int veryEasyInt;
    int easyInt;
    int normalInt;
    int hardInt;
    int veryHardInt;
    int legendaryInt;
    bool timerIsRunningMidWaves;
    float timeRemainingMidWaves;
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
    bool spawningSkeletons;

    public void Start()
    {
        SetVariables();
    }

    public void Update()
    {
        SpawnNormalSkeletonsCalculationAndSpawn();

        SpawnThrowersCalculationAndSpawn();
    }


    public void SpawnNormalSkeletonsCalculationAndSpawn()
    {
        if (timeRemaining > 0 && veryEasy == true && spawningSkeletons == true)
        {
            float veryEasyRandom = Random.Range(0.1f, 3f);
            spawnRate = veryEasyRandom * veryEasyInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && easy == true && spawningSkeletons == true)
        {
            float easyRandom = Random.Range(3.1f, 6f);
            spawnRate = easyRandom * easyInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && normal == true && spawningSkeletons == true)
        {
            float normalRandom = Random.Range(6.1f, 9f);
            spawnRate = normalRandom * normalInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && hard == true && spawningSkeletons == true)
        {
            float hardRandom = Random.Range(9.1f, 12f);
            spawnRate = hardRandom * hardInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && veryHard == true && spawningSkeletons == true)
        {
            float veryHardRandom = Random.Range(12.1f, 15f);
            spawnRate = veryHardRandom * veryHardInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && legendary == true && spawningSkeletons == true)
        {
            float legendaryRandom = Random.Range(16.1f, 20f);
            spawnRate = legendaryRandom * legendaryInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
    }

    public void SpawnThrowersCalculationAndSpawn()
    {
        if (timeRemaining > 0 && veryEasy == true && spawningSkeletons == true)
        {
            float veryEasyRandom = Random.Range(0.1f, 1f);
            spawnRate = veryEasyRandom * veryEasyInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && easy == true && spawningSkeletons == true)
        {
            float easyRandom = Random.Range(1.1f, 2f);
            spawnRate = easyRandom * easyInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && normal == true && spawningSkeletons == true)
        {
            float normalRandom = Random.Range(3.1f, 4f);
            spawnRate = normalRandom * normalInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && hard == true && spawningSkeletons == true)
        {
            float hardRandom = Random.Range(4.1f, 5f);
            spawnRate = hardRandom * hardInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && veryHard == true && spawningSkeletons == true)
        {
            float veryHardRandom = Random.Range(5.1f, 6f);
            spawnRate = veryHardRandom * veryHardInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
        else if (timeRemaining > 0 && legendary == true && spawningSkeletons == true)
        {
            float legendaryRandom = Random.Range(7.1f, 12f);
            spawnRate = legendaryRandom * legendaryInt * spawnLimit;
            spawningSkeletons = false;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
        }
    }


    public void Difficulty()
    {

    }


    public void TimerTotal()
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

                CanIncreaseSpawnLimit();
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }

    public void TimerMidWaves()
    {
        if (timerIsRunningMidWaves == true)
        {
            if (timeRemainingMidWaves > 0)
            {
                timeRemainingMidWaves -= Time.deltaTime;
                DisplayTimeMidWaves(timeRemainingMidWaves);
            }
            else if (timeRemaining <= 0)
            {
                Debug.Log("End of cycle");
                timeRemainingMidWaves = 0;
                timerIsRunningMidWaves = false;

                CanSpawnSkeletons();
            }
        }
    }

    public void DisplayTimeMidWaves(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }

    public void CanSpawnSkeletons()
    {
        if (timeRemainingMidWaves == 0 && timerIsRunningMidWaves == false)
        {
            spawningSkeletons = true;
        }
    }

    public void CanIncreaseSpawnLimit()
    {
        if (increaseTheSpawnLimitOnce == true)
        {
            spawnLimit = spawnLimit++;
            currentWave++;
            increaseTheSpawnLimitOnce = false;
        }
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
        spawnerTransform = this.GetComponent<Transform>();

        currentWave = wavesAmount;
        timeRemaining = 120;
        invokeSeconds = 4;
        veryEasyInt = 1;
        easyInt = 2;
        normalInt = 3;
        hardInt = 4;
        veryHardInt = 5;
        legendaryInt = 6;
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
