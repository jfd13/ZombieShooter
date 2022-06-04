using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_SoundEffect_BattleCry : MonoBehaviour
{

    public AudioSource skeletonBattleCry1;
    AudioSource skeletonBattleCry1Clone;
    public List<string> AudioSourceClones = new List<string>();

    public int minimumBattleCryRange;
    public int maximumBattleCryRange;
    int battleCryChance;

    public void Update()
    {
        RandomizeChanceController();
        InstantiateAudio();
    }

    public void RandomizeChanceController()
    {
        battleCryChance = Random.Range(minimumBattleCryRange, maximumBattleCryRange);
    }

    public void InstantiateAudio()
    {
        if (battleCryChance == 1)
        {
            skeletonBattleCry1Clone = Instantiate(skeletonBattleCry1);
            skeletonBattleCry1Clone.Play();
        }
    }
}
