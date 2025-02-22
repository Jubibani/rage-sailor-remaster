using System;
using UnityEngine;

public class BoatPlayer : MonoBehaviour {
 

    private CharacterController boatController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private float playerSpeed = 10.0f;
    private float jumpHeight = 20.0f;
    private float gravityValue = -9.81f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boatController = GetComponent<CharacterController>();



    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = boatController.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
            
        }
        Debug.Log("Is grounded: " + boatController.isGrounded);

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        boatController.Move(move * Time.deltaTime * playerSpeed);

        //player jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        //Gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        boatController.Move(playerVelocity * Time.deltaTime);

    }
}
