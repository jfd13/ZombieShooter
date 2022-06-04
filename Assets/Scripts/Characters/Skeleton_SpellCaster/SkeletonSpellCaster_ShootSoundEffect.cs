using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpellCaster_ShootSoundEffect : MonoBehaviour
{
    public AudioSource onSpellCastAudioSource;
    public AudioSource shootSpellCastAudioSource;
    [HideInInspector] public AudioSource onSpellCastAudioSourceClone;
    [HideInInspector] public AudioSource shootSpellCastAudioSourceClone;
    public List<AudioSource> OnShootClones = new List<AudioSource>();
    public List<AudioSource> OnSpellCastingClones = new List<AudioSource>();

    public void ShootSound()
    {
        for (int i = 0; i < 1; i++)
        {
            shootSpellCastAudioSourceClone = Instantiate(shootSpellCastAudioSource);
            OnShootClones.Add(shootSpellCastAudioSourceClone);
            shootSpellCastAudioSourceClone.Play();
        }
    }

    public void OnSpellSound()
    {
        for (int i = 0; i < 1; i++)
        {
            onSpellCastAudioSourceClone = Instantiate(onSpellCastAudioSource);
            OnShootClones.Add(onSpellCastAudioSourceClone);
            onSpellCastAudioSourceClone.Play();
        }
    }
}
