using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpJuiceBehavior : MonoBehaviour
{

    public AudioClip collectSFX;
    public float coolDown = 10;

    private Renderer renderer;

    private void Start() {
        renderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {

            CollectableBehavior.collected ++;

            AudioSource.PlayClipAtPoint(collectSFX, transform.position);

            renderer.enabled = false;

            StartCoroutine("Respawn");
        }
    }

    IEnumerator Respawn() {
        yield return new WaitForSeconds(coolDown);
        renderer.enabled = true;
    }
}
