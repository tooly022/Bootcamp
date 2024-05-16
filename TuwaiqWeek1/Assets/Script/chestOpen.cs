using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class chestOpen : MonoBehaviour
{
    private Player player;
    public SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("chest"))
        {
            player.sound.PlayChestOpen();
            Destroy(other.gameObject);
            
            
        }

    }
}
