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
    public TextMeshProUGUI whichWaveItIsText;
    public GameObject whichWaveItIsGameObject;
    public TextMeshProUGUI timeOfCurrentWave;
    public GameObject onButtonPressGameObject;
    public Transform spawnerTransform;



    int wavesAmount;
    int currentWave;
    int randomThrowersRate;
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
    bool veryEasy;
    bool easy;
    bool normal;
    bool hard;
    bool veryHard;
    bool legendary;
    bool spawningSkeletons;
    bool startButtonWasPressed;
    bool timerIsRunningPreparePhase;
    float timeRemainingPreparePhase;
    int waveTime;

    public void Start()
    {
        SetVariables();
    }

    public void Update()
    {
        SpawnNormalSkeletonsCalculationAndSpawn();

        SpawnThrowersCalculationAndSpawn();

        TimerTotal();

        TimerMidWaves();

        TimerPreparePhase();

        WavesCounter();

        Debug.Log($"Very easy: {veryEasy}");

        Debug.Log($"Spawning skeletons: {spawningSkeletons}");
    }

    public void SpawnNormalSkeletonsCalculationAndSpawn()
    {

        NormalSkeletonsVeryEasyCalculationAndSpawn();

        NormalSkeletonsEasyCalculationAndSpawn();

        NormalSkeletonsNormalCalculationAndSpawn();

        NormalSkeletonsHardCalculationAndSpawn();

        NormalSkeletonsLegendaryCalculationAndSpawn();
    }

    public void SpawnThrowersCalculationAndSpawn()
    {

        SkeletonThrowersVeryEasyCalculationAndSpawn();

        SkeletonThrowersEasyCalculationAndSpawn();

        SkeletonThrowersNormalCalculationAndSpawn();

        SkeletonThrowersHardCalculationAndSpawn();

        SkeletonThrowersVeryHardCalculationAndSpawn();

        SkeletonThrowersLegendaryCalculationAndSpawn();
    }

    public void StartButton()
    {
        startButtonWasPressed = true;
        timerIsRunningMidWaves = true;
        currentWave = 0;
    }

    public void WavesCounter()
    {
        if (startButtonWasPressed == true)
        {
            whichWaveItIsText.SetText($"Wave {currentWave}");
        }
        else if (startButtonWasPressed == false)
        {
            whichWaveItIsGameObject.SetActive(false);
        }
    }

    public void TimerTotal()
    {
        if (timerIsRunning == true && startButtonWasPressed == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                timerIsRunningMidWaves = true;
            }
            else if (timeRemaining <= 0)
            {
                Debug.Log("End of the wave");
                timeRemaining = 0;
                timerIsRunning = false;
                timerIsRunningMidWaves = false;
                timerIsRunningPreparePhase = true;

                increaseTheSpawnLimitOnce = true;
                CanIncreaseSpawnLimitAndWave();
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeOfCurrentWave.SetText($"{minutes}:{seconds}");
        //Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }

    public void TimerMidWaves()
    {
        if (timerIsRunningMidWaves == true && startButtonWasPressed == true)
        {
            if (timeRemainingMidWaves > 0)
            {
                timeRemainingMidWaves -= Time.deltaTime;
                DisplayTimeMidWaves(timeRemainingMidWaves);
            }
            else if (timeRemainingMidWaves <= 0)
            {
                Debug.Log("End of cycle");
                CanSpawnSkeletons();
                timeRemainingMidWaves = 5;
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

    public void TimerPreparePhase()
    {
        if (timerIsRunningPreparePhase == true)
        {
            if (timeRemainingPreparePhase > 0)
            {
                timeRemainingPreparePhase -= Time.deltaTime;
                DisplayTime(timeRemainingPreparePhase);
            }
            else
            {
                Debug.Log("Break time has run out");
                timeRemainingPreparePhase = 0;
                timerIsRunningPreparePhase = false;
                timerIsRunning = true;
                timeRemaining = waveTime;
            }
        }
    }

    public void DisplayTimePreparePhase(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }

    public void CanSpawnSkeletons()
    {
        if (timeRemainingMidWaves <= 0)
        {
            Debug.Log("Inside can spawn skeleton");
            spawningSkeletons = true;
        }
    }

    public void CanIncreaseSpawnLimitAndWave()
    {
        if (currentWave < wavesAmount && increaseTheSpawnLimitOnce == true)
        {
            spawnLimit = spawnLimit++;
            currentWave++;
            onButtonPressText.SetText($"Wave number {currentWave}");
            increaseTheSpawnLimitOnce = false;
        }
        else if (currentWave >= wavesAmount && increaseTheSpawnLimitOnce == true)
        {
            onButtonPressText.SetText($"Wave number {wavesAmount}");
            increaseTheSpawnLimitOnce = false;
        }
    }



    public void NormalSkeletonsVeryEasyCalculationAndSpawn()
    {
        Debug.Log("Inside very easy spawn");
        if (timeRemaining > 0 && veryEasy == true && spawningSkeletons == true)
        {
            float veryEasyRandom = Random.Range(0.1f, 3f);
            spawnRate = veryEasyRandom * veryEasyInt * spawnLimit;

            Debug.Log("Inside very easy IF");

            for (int i = 0; i < spawnRate; i++)
            {
                Debug.Log("Inside very FOR");

                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
            spawningSkeletons = false;
        }
    }

    public void NormalSkeletonsEasyCalculationAndSpawn()
    {
        if (timeRemaining > 0 && easy == true && spawningSkeletons == true)
        {
            float easyRandom = Random.Range(3.1f, 6f);
            spawnRate = easyRandom * easyInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
            spawningSkeletons = false;
        }
    }

    public void NormalSkeletonsNormalCalculationAndSpawn()
    {
        if (timeRemaining > 0 && normal == true && spawningSkeletons == true)
        {
            float normalRandom = Random.Range(6.1f, 9f);
            spawnRate = normalRandom * normalInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
            spawningSkeletons = false;
        }
    }

    public void NormalSkeletonsHardCalculationAndSpawn()
    {
        if (timeRemaining > 0 && hard == true && spawningSkeletons == true)
        {
            float hardRandom = Random.Range(9.1f, 12f);
            spawnRate = hardRandom * hardInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
            spawningSkeletons = false;
        }
    }

    public void NormalSkeletonsVeryHardCalculationAndSpawn()
    {
        if (timeRemaining > 0 && veryHard == true && spawningSkeletons == true)
        {
            float veryHardRandom = Random.Range(12.1f, 15f);
            spawnRate = veryHardRandom * veryHardInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
            spawningSkeletons = false;
        }
    }

    public void NormalSkeletonsLegendaryCalculationAndSpawn()
    {
        if (timeRemaining > 0 && legendary == true && spawningSkeletons == true)
        {
            float legendaryRandom = Random.Range(16.1f, 20f);
            spawnRate = legendaryRandom * legendaryInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                Instantiate(skeletonNormal, spawnerTransform.position, spawnerTransform.rotation);
            }
            spawningSkeletons = false;
        }
    }



    public void SkeletonThrowersVeryEasyCalculationAndSpawn()
    {
        if (timeRemaining > 0 && veryEasy == true && spawningSkeletons == true)
        {
            float veryEasyRandom = Random.Range(0.1f, 1f);
            spawnRate = veryEasyRandom * veryEasyInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                randomThrowersRate = Random.Range(0, 3);

                if (randomThrowersRate == 0)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        Instantiate(skeletonFrisbeeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 1)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        Instantiate(skeletonGrenadeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 2)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        Instantiate(skeletonSpellCaster, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
            }
            spawningSkeletons = false;
        }
    }

    public void SkeletonThrowersEasyCalculationAndSpawn()
    {
        if (timeRemaining > 0 && easy == true && spawningSkeletons == true)
        {
            float easyRandom = Random.Range(1.1f, 2f);
            spawnRate = easyRandom * easyInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                randomThrowersRate = Random.Range(0, 3);

                if (randomThrowersRate == 0)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        Instantiate(skeletonFrisbeeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 1)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        Instantiate(skeletonGrenadeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 2)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        Instantiate(skeletonSpellCaster, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
            }
            spawningSkeletons = false;
        }
    }

    public void SkeletonThrowersNormalCalculationAndSpawn()
    {
        if (timeRemaining > 0 && normal == true && spawningSkeletons == true)
        {
            float normalRandom = Random.Range(3.1f, 4f);
            spawnRate = normalRandom * normalInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                randomThrowersRate = Random.Range(0, 3);

                if (randomThrowersRate == 0)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        Instantiate(skeletonFrisbeeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 1)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        Instantiate(skeletonGrenadeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 2)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        Instantiate(skeletonSpellCaster, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
            }
            spawningSkeletons = false;
        }
    }

    public void SkeletonThrowersHardCalculationAndSpawn()
    {
        if (timeRemaining > 0 && hard == true && spawningSkeletons == true)
        {
            float hardRandom = Random.Range(4.1f, 5f);
            spawnRate = hardRandom * hardInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                randomThrowersRate = Random.Range(0, 3);

                if (randomThrowersRate == 0)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        Instantiate(skeletonFrisbeeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 1)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        Instantiate(skeletonGrenadeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 2)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        Instantiate(skeletonSpellCaster, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
            }
            spawningSkeletons = false;
        }
    }

    public void SkeletonThrowersVeryHardCalculationAndSpawn()
    {
        if (timeRemaining > 0 && veryHard == true && spawningSkeletons == true)
        {
            float veryHardRandom = Random.Range(5.1f, 6f);
            spawnRate = veryHardRandom * veryHardInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                randomThrowersRate = Random.Range(0, 3);

                if (randomThrowersRate == 0)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        Instantiate(skeletonFrisbeeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 1)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        Instantiate(skeletonGrenadeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 2)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        Instantiate(skeletonSpellCaster, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
            }
            spawningSkeletons = false;
        }
    }

    public void SkeletonThrowersLegendaryCalculationAndSpawn()
    {
        if (timeRemaining > 0 && legendary == true && spawningSkeletons == true)
        {
            float legendaryRandom = Random.Range(7.1f, 12f);
            spawnRate = legendaryRandom * legendaryInt * spawnLimit;

            for (int i = 0; i < spawnRate; i++)
            {
                randomThrowersRate = Random.Range(0, 3);

                if (randomThrowersRate == 0)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        Instantiate(skeletonFrisbeeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 1)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        Instantiate(skeletonGrenadeThrower, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
                else if (randomThrowersRate == 2)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        Instantiate(skeletonSpellCaster, spawnerTransform.position, spawnerTransform.rotation);
                    }
                }
            }
            spawningSkeletons = false;
        }
    }



    public void OnButtonPressVeryEasy()
    {
        DifficultyVariables(true, false, false, false, false, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("VERY EASY SELECTED");
        onButtonPressText.SetText("VERY EASY");
    }

    public void OnButtonPressEasy()
    {
        DifficultyVariables(false, true, false, false, false, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("EASY SELECTED");
        onButtonPressText.SetText("EASY");
    }

    public void OnButtonPressNormal()
    {
        DifficultyVariables(false, false, true, false, false, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("NORMAL SELECTED");
        onButtonPressText.SetText("NORMAL");
    }

    public void OnButtonPressHard()
    {
        DifficultyVariables(false, false, false, true, false, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("HARD SELECTED");
        onButtonPressText.SetText("HARD");
    }

    public void OnButtonPressVeryHard()
    {
        DifficultyVariables(false, false, false, false, true, false);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("VERY HARD SELECTED");
        onButtonPressText.SetText("VERY HARD");
    }
    public void OnButtonPressLegendary()
    {
        DifficultyVariables(false, false, false, false, false, true);
        onButtonPressGameObject.SetActive(true);
        onButtonPressText.SetText("LEGENDARY SELECTED");
        onButtonPressText.SetText("LEGENDARY");
    }

    public void OnButtonPressSetWave10()
    {
        wavesAmount = 10;
    }

    public void OnButtonPressSetWave20()
    {
        wavesAmount = 20;
    }

    public void OnButtonPressSetWave30()
    {
        wavesAmount = 30;
    }

    public void OnButtonPressSetWave40()
    {
        wavesAmount = 40;
    }

    public void OnButtonPressSetWave50()
    {
        wavesAmount = 50;
    }

    public void OnButtonPressSetWaveUnlimited()
    {
        wavesAmount = 9999;
    }

    public void SetVariables()
    {
        onButtonPressGameObject.SetActive(false);
        currentWave = 1;
        timeRemaining = 120;
        veryEasyInt = 1;
        easyInt = 2;
        normalInt = 3;
        hardInt = 4;
        veryHardInt = 5;
        legendaryInt = 6;
        spawnLimit = 1;
        timeRemainingMidWaves = 5;
        timerIsRunning = true;
        veryEasy = false;
        easy = false;
        normal = false;
        hard = false;
        veryHard = false;
        legendary = false;
        startButtonWasPressed = false;
        timerIsRunningPreparePhase = false;
        timerIsRunningMidWaves = false;
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
