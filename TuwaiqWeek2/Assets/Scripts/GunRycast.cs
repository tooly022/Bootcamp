using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class GunRycast : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDruation = 0.05f;


    LineRenderer laserLine;
    float firstTimer;

    // Start is called before the first frame update
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        firstTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1")&& firstTimer> fireRate)
        {
            firstTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);
                Destroy(hit.transform.gameObject);

            }else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));

            }
            StartCoroutine(ShootLaser());

        }
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDruation);
        laserLine.enabled = false;
    }
}
