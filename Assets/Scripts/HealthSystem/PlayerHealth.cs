using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;

    public float maxHealth;
    float currentHealth;
    float randomModifier;
    public float minRandomModifier;
    public float maxRandomModifier;


    public void Start()
    {
        currentHealth = maxHealth;

        SetVariables();
    }

    public void Health(float healthSubstraction)
    {
        randomModifier = Random.Range(minRandomModifier, maxRandomModifier);

        currentHealth -= healthSubstraction * randomModifier;
        healthBar.value = currentHealth;

        if (currentHealth > 0)
        {
            return;
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Play sound
        //Screen goes black
        //Game over screen
    }

    public void SetVariables()
    {
        currentHealth = maxHealth;
    }
}
