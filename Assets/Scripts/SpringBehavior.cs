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
            StartCoroutine("PlayAnim");
            AudioSource.PlayClipAtPoint(springSFX, transform.position);
            
        }
    }
    IEnumerator PlayAnim()
    {
        gameObject.GetComponent<Animator>().SetTrigger("springActivate");
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Animator>().ResetTrigger("springActivate");
    }
}
