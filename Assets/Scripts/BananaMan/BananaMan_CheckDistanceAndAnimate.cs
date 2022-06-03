using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaMan_CheckDistanceAndAnimate : MonoBehaviour
{
    public Animator bananaManAnimator;
    public Transform player;
    public Transform bananaManTransform;
    public BananaMan_Variables bananaManVariablesScript;


    float distance;
    float distanceBeforeRuning;

    public void Update()
    {
        Variables();
        DistanceCheck();
    }

    public void DistanceCheck()
    {
        distance = Vector3.Distance(player.transform.position, bananaManTransform.transform.position);

        if (distance > distanceBeforeRuning)
        {
            AnimationController(false, true);
        }

        else if (distance < distanceBeforeRuning)
        {
            AnimationController(true, false);
        }
    }

    public void AnimationController(bool runing, bool idle)
    {
        bananaManAnimator.SetBool("Runing", runing);
        bananaManAnimator.SetBool("Idle", idle);
    }

    public void Variables()
    {
        distanceBeforeRuning = bananaManVariablesScript.distanceBeforeRuning;
    }
}
