﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableBehavior : MonoBehaviour
{

    public static int collected = 0;
    public Text scoreText;
    public AudioClip collectSFX;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null) {
            GameObject scoreTextObject = GameObject.FindGameObjectWithTag("ScoreText");
            scoreText = scoreTextObject.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {

            CollectableBehavior.collected ++;

            UpdateUI();

            AudioSource.PlayClipAtPoint(collectSFX, transform.position);

            Destroy(gameObject);
        }
    }

    void UpdateUI() {
        scoreText.text = "Score: " + collected;
    }
}
