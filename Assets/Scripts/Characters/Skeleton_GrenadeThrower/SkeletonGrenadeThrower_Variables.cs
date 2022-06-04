using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGrenadeThrower_Variables : MonoBehaviour
{
    public int ObstacleDistanceCheck; //Checking distance before turning
    public float grenadeThrowDistance; //Float throwing distance, distance which determines if skeleton can already throw or not
    public float slapDistance; //Float slap distance
    public float speedOfGrenadeProjectile; //Speed at which grenade flies towards the player
    public float timeOfGrenadeExplosion; //Time in which grenade explodes
    public float radiusOfGrenadeExplosion; //Radius in which items are affected by explosion 
    public float explosionForceOfGrenade; //A force of explosion on items in radius
    public float upwardForceOnGrenadeExplosion; //A force of explosion on items in radius upwards
}
