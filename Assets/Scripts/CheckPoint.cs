using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    public GameObject player;

   
    private Transform checkpointLocation;

    public GameObject CheckpointChecked;
    public GameObject CheckpointUnchecked;
    public static bool check = false;

    void Start()
    {
        checkpointLocation = CheckpointChecked.transform;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            check = true;
            CheckpointChecked.SetActive(true);
            CheckpointUnchecked.SetActive(false);
        }
    }

    public void JumpToCheckpoint()
    {
        player.transform.position = checkpointLocation.position;
        player.transform.rotation = checkpointLocation.rotation;
    }
}
