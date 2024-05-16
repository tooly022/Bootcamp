using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.RectTransform;

public class gameHandler : MonoBehaviour
{
    public Slider slider;
    public Slider enemySlider;
    HealthSystem healthSystem = new HealthSystem(100);
    EnemyHealthSystem enemyHealthSystem = new EnemyHealthSystem(30);


    // Start is called before the first frame update
    void Start()
    {
        //slider = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = healthSystem.getHealthPercentage();
        enemySlider.value = enemyHealthSystem.getEnemyHealthPercentage();

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "heal")
        {

            healthSystem.heal(10);
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            healthSystem.Damage(10);
        }
    }
}