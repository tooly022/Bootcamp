using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bullet;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
    }
}
