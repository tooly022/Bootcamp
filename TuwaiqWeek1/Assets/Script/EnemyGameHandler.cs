using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGameHandler : MonoBehaviour
{
    public Slider enemySlider;
    EnemyHealthSystem enemyHealthSystem = new EnemyHealthSystem(30);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemySlider.value = enemyHealthSystem.getEnemyHealthPercentage();

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            enemyHealthSystem.DamageEnemy(10);
            if (enemyHealthSystem.getEnemyHealth() == 0)
            {
                Destroy(gameObject);
            }

        }else if (collision.gameObject.tag == "laser")
        {
            enemyHealthSystem.DamageEnemy(30);
            if (enemyHealthSystem.getEnemyHealth() == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
