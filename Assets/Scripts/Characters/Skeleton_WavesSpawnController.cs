using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_WavesSpawnController : MonoBehaviour
{
    public GameObject skeletonNormal;
    public GameObject skeletonFrisbeeThrower;
    public GameObject skeletonSpellCaster;
    public GameObject skeletonGrenadeThrower;
    public List<GameObject> Spawners = new List<GameObject>();



    public int waves;
    public int currentWave;


}
