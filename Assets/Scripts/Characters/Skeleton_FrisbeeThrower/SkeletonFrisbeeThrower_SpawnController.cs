using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFrisbeeThrower_SpawnController : MonoBehaviour
{
    public GameObject skeletonGameObject; //Skeleton game object
    public GameObject spawnerGameObject; //Spawner game object
    [HideInInspector] public GameObject skeletonGameObjectClone; //Skeleton game object clone

    //-------------------------------------------------------------------------------------------------------------------------------

    public int minimumSkeletonSpawnRange; //Minimum number of skeleton spawn
    public int maximumSkeletonSpawnRange; //Maximum number of skeleton spawn
    static float spawnRate; //The rate at which skeletons spawn
    static float nextSpawn; //Next skeleton spawn allowance
    public List<GameObject> skeletonClones = new List<GameObject>(); //List for skeleton clones

    public void Awake()
    {
        //Create a skeleton clone at the start so I can equate it with other information
        skeletonGameObjectClone = Instantiate(skeletonGameObject, spawnerGameObject.transform.position, skeletonGameObject.transform.rotation);
    }

    public void Update()
    {

        if (Time.time > nextSpawn)
        {
            //Spawner with timer which is determined by spawnRate + random.range(min,max) number
            nextSpawn = Time.time + spawnRate;
            spawnRate = Random.Range(minimumSkeletonSpawnRange, maximumSkeletonSpawnRange);

            //Call Spawner method
            Spawner();
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------

    public void Spawner()
    {
        //Created a loop in which skeletons are saved so that pathing works
        for (int i = 0; i < 1; i++)
        {
            skeletonClones.Add(skeletonGameObjectClone = Instantiate(skeletonGameObject, spawnerGameObject.transform.position, skeletonGameObject.transform.rotation));
        }
    }
}
