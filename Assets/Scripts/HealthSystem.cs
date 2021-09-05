using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    int maxHealth;
    int currentHealth;

    public int MaxHealth
    {
        set
        {
            maxHealth = value;           
        }

        get
        {
            return maxHealth;
        }
    }
    
    public int CurrentHealth
    {
        set
        {
            currentHealth = value;
        }

        get
        {
            return currentHealth;
        }
    }

    public void Damage(int damageAmount)
    {      
        if(!(currentHealth <= 0))
        {
            currentHealth -= damageAmount;
        }
        else
        {
            currentHealth = 0;
            Debug.Log("GameOver");
        }        
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
