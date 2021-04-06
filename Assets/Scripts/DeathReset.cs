using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathReset : MonoBehaviour
{
    public CheckPoint point;
    public AudioClip deathSFX;
    public Transform PlayerLocation;


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (CheckPoint.check)
            {
                AudioSource.PlayClipAtPoint(deathSFX, PlayerLocation.position);
                point.JumpToCheckpoint();
            }
        }
    }
}
