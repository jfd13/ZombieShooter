using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaMan_CheckDistanceAndAnimate : MonoBehaviour
{
    public Animator bananaManAnimator; //Animator component of banana man
    public Transform player; //Player transform component
    public Transform bananaManTransform; //Transform component of banana man
    public BananaMan_Variables bananaManVariablesScript; //Script of banana man variables
    public AudioSource bananaManScream; //Scream of banana man, audio source

    //----------------------------------------------------------------------------------------------------------------------------------------------

    float distance; //Distance between player and banana man
    float distanceBeforeRuning; //Distance before runing away from player
    float maxRayCastDistance; //Max raycast distance
    bool raycast; //Raycast bool for raycasting
    bool canRunOrNot; //Checks if he already ran or not

    //----------------------------------------------------------------------------------------------------------------------------------------------

    public void Start()
    {
        //Can run or not on true at start
        canRunOrNot = true;
    }

    public void Update()
    {
        //Variables method
        Variables();

        //Distance check method
        DistanceCheck();

        //Raycasting method
        Raycasting();
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------DISTANCE CHECK

    //Checks distance inside, between player and banana man and runs if its below certain distance
    public void DistanceCheck()
    {
        distance = Vector3.Distance(player.transform.position, bananaManTransform.transform.position);

        if (distance < distanceBeforeRuning && canRunOrNot == true)
        {
            Debug.Log("Runing away");
            StartCoroutine(RuningTimer());
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------RAYCASTING

    //Raycasting for walls, if its true he turns if not he does not
    public void Raycasting()
    {
        raycast = Physics.Raycast(bananaManTransform.position, bananaManTransform.forward, out RaycastHit hitInfoF, maxRayCastDistance);

        if (raycast == true)
        {
            Debug.Log("Wall");
            bananaManTransform.Rotate(0, 5, 0);
        }
        else
        {
            Debug.Log("Nothing");
            bananaManTransform.Rotate(0, 0, 0);
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------ANIMATION CONTROLLER

    //Animation controller method
    public void AnimationController(bool runing, bool idle)
    {
        bananaManAnimator.SetBool("Runing", runing);
        bananaManAnimator.SetBool("Idle", idle);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------RUNING TIMER

    //Runing IEnumerator timer in which I set the animation to true and false after so many seconds
    IEnumerator RuningTimer()
    {
        AnimationController(true, false);
        canRunOrNot = false;
        bananaManScream.Play();
        yield return new WaitForSeconds(3.5f);
        AnimationController(false, true);
        canRunOrNot = true;
    }


    //----------------------------------------------------------------------------------------------------------------------------------------------VARIABLES


    //Get variables from variable script
    public void Variables()
    {
        distanceBeforeRuning = bananaManVariablesScript.distanceBeforeRuning;
        maxRayCastDistance = bananaManVariablesScript.WallCheckDistance;
    }
}
