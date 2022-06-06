using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotationAndSound_DIFFICULTY : MonoBehaviour
{
    public Transform canvas;
    public Transform player;
    public AudioClip[] audioClips = new AudioClip[0];
    public AudioSource onClickAudioSource;


    int random;

    public void Update()
    {
        TurnToPlayer();
    }

    public void TurnToPlayer()
    {
        Vector3 lookPos = player.position - canvas.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY - 180, 0);
        canvas.transform.rotation = rotation;
    }

    public void OnClickSound()
    {
        random = Random.Range(0, 12);
        Debug.Log(random);

        onClickAudioSource.clip = audioClips[random];

        if (onClickAudioSource.clip != null)
        {
            onClickAudioSource.Play();
        }
        else if (onClickAudioSource.clip == null)
        {
            onClickAudioSource.clip = audioClips[1];
            onClickAudioSource.Play();
        }
    }
}
