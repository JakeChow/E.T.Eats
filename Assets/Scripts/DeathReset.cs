using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathReset : MonoBehaviour
{
    public CheckPoint point;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered");

        if (other.CompareTag("Player"))
        {
            if (point.Checked())
            {
                Debug.Log("Player entered");
                point.JumpToCheckpoint();
            }
        }
    }
}
