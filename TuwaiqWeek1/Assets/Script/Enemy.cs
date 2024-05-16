using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speedEnemy;
    private GameObject Player;
    private bool detected = false;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bullet;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float playerDistance = Vector3.Distance(Player.transform.position, transform.position);
        Debug.Log("Distance between plaver and enemy:" + playerDistance);

        if (playerDistance <= 5 && detected == false)

            detected = true;

        if (detected == true)
        {
            if (Player.transform.position.x < transform.position.x)
            {
                transform.Translate(Vector3.right * -speedEnemy * Time.deltaTime);
                Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);

            }
            else
            {
                transform.Translate(Vector3.right * speedEnemy * Time.deltaTime);
                Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);

            }
            if (Player.transform.position.z < transform.position.z)
            {
                transform.Translate(Vector3.forward * -speedEnemy * Time.deltaTime);
                Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);

            }
            else
            {
                transform.Translate(Vector3.forward * speedEnemy * Time.deltaTime);
                Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);

            }
        }
    }
}
