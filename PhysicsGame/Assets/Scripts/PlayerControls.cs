using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody player;
    public GameObject mouseTracker;

    public float moveSpeed = 6f;
    public float playerHeading;
    public float rotationSpeed = 6f;

    void Start()
    {
        
    }

    void Update()
    {

        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        var forward = Camera.main.transform.forward;
        var right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        var moveDirection = forward * verticalAxis + right * horizontalAxis;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        player.rotation = Quaternion.Euler(0, playerHeading, 0);

        if(Input.GetKey(KeyCode.Q))
        {
            playerHeading = playerHeading - rotationSpeed;
        }

        if(Input.GetKey(KeyCode.E))
        {
            playerHeading = playerHeading + rotationSpeed;
        }

    }
}
