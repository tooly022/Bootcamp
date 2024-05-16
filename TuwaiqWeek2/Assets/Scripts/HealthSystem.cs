using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float heathPoint;
    private float maxHealth;


    public HealthSystem (int maxHealth)
    {
        this.maxHealth = maxHealth;
        heathPoint = maxHealth;
    }

    public float getHealth() { return heathPoint; }

    public float getHealthPercentage() { return heathPoint / maxHealth; }

    public void Damage(int damageAmount)
    {
        heathPoint -= damageAmount;
        if(heathPoint <= 0) { heathPoint = 0; }
    }

    public void heal(int healAmount)
    {
        
            heathPoint += healAmount;
       
        if (heathPoint > maxHealth)
        {
            heathPoint = maxHealth;
        }
        
    }
   
}
