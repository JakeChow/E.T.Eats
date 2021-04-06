using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    private GameObject player;

    private bool check = false;
    private Transform checkpointLocation;

    public GameObject CheckpointChecked;
    public GameObject CheckpointUnchecked;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        checkpointLocation = CheckpointChecked.transform;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckpointChecked.SetActive(true);
            CheckpointUnchecked.SetActive(false);
            check = true;
        }
    }

    public void JumpToCheckpoint()
    {
            Debug.Log("Hello");
            player.transform.position = checkpointLocation.position;
    
    }

    public bool Checked()
    {
        return check;
    }
}
