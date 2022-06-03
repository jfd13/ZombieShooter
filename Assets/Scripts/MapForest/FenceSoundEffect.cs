using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSoundEffect : MonoBehaviour
{
    public List<GameObject> Fences = new List<GameObject>(); //List of fences used to destroy them later
    public Transform player; //Transform component of player
    public Transform bananaMan; //Banana man transform component
    public AudioSource fenceDestructionAudioSource1; //Audio source for fence destruction
    public AudioSource fenceDestructionAudioSource2; //Audio source for fence destruction
    public AudioSource fenceDestructionAudioSource3; //Audio source for fence destruction
    public AudioSource fenceDestructionAudioSource4; //Audio source for fence destruction
    AudioSource fenceDestructionAudioSourceClone; //Audio source clone for fence destruction

    //----------------------------------------------------------------------------------------------------------------------------------------------

    float distance1; //Distance of player and fence
    float distance2; //Distance of banana man and fence
    int randomSound; //Sound randomized, which sound plays later when fence was destroyed

    public void Update()
    {
        //Calling distance checking method
        DistanceCheck();
    }

    //Distance checking method in which i check if player/bananaman can destroy fence or not
    public void DistanceCheck()
    {
        //Randomize the number between 0-3 for sound
        randomSound = Random.Range(0, 4);

        //Check in for statement if any of the fences can get destroyed already
        for (int i = 0; i < Fences.Count; i++)
        {
            //If its null then continue (in case if its already destroyed the list doesnt know)
            if (Fences[i] == null)
            {
                continue;
            }
            //If not null check distance and clone sound and play it and destroy fence
            else if (Fences[i] != null)
            {
                //Distance between player and fence
                distance1 = Vector3.Distance(Fences[i].transform.position, player.transform.position);

                //Distance between fence and banana man
                distance2 = Vector3.Distance(Fences[i].transform.position, bananaMan.transform.position);

                if (distance2 < 2 || distance1 < 2 && randomSound == 0)
                {
                    //Destroy fence (the same for below statements)
                    Destroy(Fences[i]);

                    //Clone sound (the same for below statements)
                    fenceDestructionAudioSourceClone = Instantiate(fenceDestructionAudioSource1, player.transform.position, player.transform.rotation);

                    //Play clone sound (the same for below statements)
                    fenceDestructionAudioSourceClone.Play();
                }
                else if (distance2 < 2 || distance1 < 2 && randomSound == 1)
                {
                    Destroy(Fences[i]);
                    fenceDestructionAudioSourceClone = Instantiate(fenceDestructionAudioSource2, player.transform.position, player.transform.rotation);
                    fenceDestructionAudioSourceClone.Play();
                }
                else if (distance2 < 2 || distance1 < 2 && randomSound == 2)
                {
                    Destroy(Fences[i]);
                    fenceDestructionAudioSourceClone = Instantiate(fenceDestructionAudioSource3, player.transform.position, player.transform.rotation);
                    fenceDestructionAudioSourceClone.Play();
                }
                else if (distance2 < 2 || distance1 < 2 && randomSound == 3)
                {
                    Destroy(Fences[i]);
                    fenceDestructionAudioSourceClone = Instantiate(fenceDestructionAudioSource4, player.transform.position, player.transform.rotation);
                    fenceDestructionAudioSourceClone.Play();
                }
            }
        }
    }
    
}
