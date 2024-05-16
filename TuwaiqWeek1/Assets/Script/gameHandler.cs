using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameHandler : MonoBehaviour
{
    public Slider slider;
    HealthSystem healthSystem = new HealthSystem(100);


    // Start is called before the first frame update
    void Start()
    {
        //slider = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = healthSystem.getHealthPercentage();

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
