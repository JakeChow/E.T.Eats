using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBehavior : MonoBehaviour
{

    
    public AudioClip springSFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("springActivate");
            AudioSource.PlayClipAtPoint(springSFX, transform.position);
            
        }
    }

}
