using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    private float heathPoint;
    private float maxHealth;


    public EnemyHealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        heathPoint = maxHealth;
    }

    public float getEnemyHealth() { return heathPoint; }

    public float getEnemyHealthPercentage() { return heathPoint / maxHealth; }

    public void DamageEnemy(int damageAmount)
    {
        heathPoint -= damageAmount;
        if (heathPoint <= 0) {
            heathPoint = 0;
        }
    }

    //public void heal(int healAmount)
    //{

    //    heathPoint += healAmount;

    //    if (heathPoint > maxHealth)
    //    {
    //        heathPoint = maxHealth;
    //    }

    //}
}
