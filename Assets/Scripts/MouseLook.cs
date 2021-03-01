using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    Transform cameraTransform;
    Transform playerTransform;

    public float mouseSens = 1;

    private float pitch = 0f;

    Vector2 rotation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform.parent.transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotation.y = playerTransform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X") * mouseSens;
        rotation.x -= Input.GetAxis("Mouse Y") * mouseSens;
        rotation.x = Mathf.Clamp(rotation.x, -24, 60);
        playerTransform.eulerAngles = new Vector2(0, rotation.y);
        cameraTransform.eulerAngles = new Vector2(rotation.x, rotation.y);
    }
}