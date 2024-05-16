using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource , walk;
    public AudioClip jump, chestOpen, gun, laser;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(jump);
    }

    
    public void PlayChestOpen()
    {
        audioSource.PlayOneShot(chestOpen);
    }

    public void PlayGun()
    {
        audioSource.PlayOneShot(gun);
    }

    public void PlayLaser()
    {
        audioSource.PlayOneShot(laser);
    }
}
