using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Hitpoint : MonoBehaviour
{
    [HideInInspector] public AudioSource audioSourceClone;
    public AudioSource audioSource;
    public Transform playerTransform;
    public AudioClip[] AudioClips = new AudioClip[1];
    [HideInInspector] public GameObject skeleton;
    public PlayerHealth playerHealthScript;


    [HideInInspector] public int randomNumber;
    Vector3 lastHitBoxPosition;
    Vector3 currentPosition;
    float velocity;
    float timeRemaining;
    bool timerIsRunning = true;
    bool isSpeedHighEnoughBool;
    bool isInsideOfPlayer;
    bool didHitHappen;


    public void Start()
    {

        FindParent();
    }

    public void Update()
    {
        randomNumber = Random.Range(0, 2);

        HitSpeed();

        isSpeedHighEnough();

        isSpeedHighEnoughTimer();

        IsInsideThePlayerOrNot();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInsideOfPlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isInsideOfPlayer = false;
    }

    public float VelocityCalculation()
    {
        return Mathf.Abs(((currentPosition - lastHitBoxPosition) / Time.deltaTime).magnitude);
    }

    public void HitSpeed()
    {
        currentPosition = skeleton.transform.position - transform.position;
        VelocityCalculation();
        velocity = VelocityCalculation();
        lastHitBoxPosition = currentPosition;
    }

    public void isSpeedHighEnough()
    {
        if (velocity > 15)
        {
            isSpeedHighEnoughBool = true;
            timeRemaining = 0.5f;
            timerIsRunning = true;
        }
    }


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

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Debug.Log($"Minutes: {minutes}, Seconds: {seconds}");
    }

    public void IsInsideThePlayerOrNot()
    {
        if (isInsideOfPlayer == true && isSpeedHighEnoughBool == true && didHitHappen == false)
        {
            isSpeedHighEnoughBool = false;
            didHitHappen = true;
            playerHealthScript.Health(1);
            Debug.Log("Hit the player");
            //Hit player
        }
    }


    private void FindParent()
    {
        skeleton = transform.gameObject;
        while (skeleton.layer != LayerMask.NameToLayer("Skeleton"))
        {
            skeleton = skeleton.transform.parent.gameObject;
        }
    }
}
