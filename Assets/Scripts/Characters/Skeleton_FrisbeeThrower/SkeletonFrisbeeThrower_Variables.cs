using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFrisbeeThrower_Variables : MonoBehaviour
{
    public float swordThrowDistance; //Distance at which skeleton throws sword at player
    public float slapDistance; //Distance at which skeleton slaps player
    public int ObstacleDistanceCheck; //Distance before skeleton starts turning if obstacle on the way
    public float speedOfSwordProjectile; //The speed at which sword/projectile of frisbee thrower flies towards the player
    public float distanceCheckRate; //The rate at which skeletons checks for the distance between player and himself to prevent lag
}
