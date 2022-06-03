using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSoundEffect : MonoBehaviour
{
    public List<GameObject> Fences = new List<GameObject>();
    public Transform player;
    public AudioSource fenceDestructionAudioSource1;
    public AudioSource fenceDestructionAudioSource2;
    public AudioSource fenceDestructionAudioSource3;
    public AudioSource fenceDestructionAudioSource4;
    AudioSource fenceDestructionAudioSourceClone;

    float distance;
    int randomSound;

    public void Update()
    {
        DistanceCheck();

        Debug.Log(distance);
    }

    public void DistanceCheck()
    {
        randomSound = Random.Range(0, 4);

        for (int i = 0; i < Fences.Count; i++)
        {
            if (Fences[i] == null)
            {
                continue;
            }
            else if (Fences[i] != null)
            {
                distance = Vector3.Distance(Fences[i].transform.position, player.transform.position);

                if (distance < 2 && randomSound == 0)
                {
                    Destroy(Fences[i]);
                    fenceDestructionAudioSourceClone = Instantiate(fenceDestructionAudioSource1, player.transform.position, player.transform.rotation);
                    fenceDestructionAudioSourceClone.Play();
                }
                else if (distance < 2 && randomSound == 1)
                {
                    Destroy(Fences[i]);
                    fenceDestructionAudioSourceClone = Instantiate(fenceDestructionAudioSource2, player.transform.position, player.transform.rotation);
                    fenceDestructionAudioSourceClone.Play();
                }
                else if (distance < 2 && randomSound == 2)
                {
                    Destroy(Fences[i]);
                    fenceDestructionAudioSourceClone = Instantiate(fenceDestructionAudioSource3, player.transform.position, player.transform.rotation);
                    fenceDestructionAudioSourceClone.Play();
                }
                else if (distance < 2 && randomSound == 3)
                {
                    Destroy(Fences[i]);
                    fenceDestructionAudioSourceClone = Instantiate(fenceDestructionAudioSource4, player.transform.position, player.transform.rotation);
                    fenceDestructionAudioSourceClone.Play();
                }
            }
        }
    }
    
}
