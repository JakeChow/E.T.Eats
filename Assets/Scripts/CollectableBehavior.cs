using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableBehavior : MonoBehaviour
{

    public static int collected = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {

            CollectableBehavior.collected ++;

            UpdateUI();

            Destroy(gameObject);
        }
    }

    void UpdateUI() {
        scoreText.text = "Score: " + collected;
    }
}
