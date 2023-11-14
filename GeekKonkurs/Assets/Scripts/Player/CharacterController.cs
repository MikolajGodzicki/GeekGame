using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    //private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float targetRotation;
    
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        targetRotation = GameObject.Find("CameraController").GetComponent<CameraController>().targetRotation;
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if(targetRotation == 0f){
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Move(move);
        }
        else if(targetRotation == -90f || targetRotation == 270f){
            Vector3 move = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            Move(move);
        }
        else if(targetRotation == -180f || targetRotation == 180f){
            Vector3 move = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
            Move(move);
        }
        else if(targetRotation == -270f || targetRotation == 90f){
            Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
            Move(move);
        }

        /*if (move != Vector3.zero)
        {
            //gameObject.transform.forward = move;
        }

        //Changes the height position of the player..
        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Move(Vector3 move) => controller.Move(move * Time.deltaTime * playerSpeed);
}