using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    //private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float targetRotation;
    private Vector2 _playerMovementInput;
    public float Xrange;
    public float Yrange;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Moveplayer();
        if (transform.position.x > Xrange)
        {   
            if (targetRotation == 0f)
            {
                _playerMovementInput.x = -0.1f;
            }
            else if(targetRotation == -270f || targetRotation == 90f)
            {
                _playerMovementInput.y = -0.1f;
            }
            else if (targetRotation == -90f || targetRotation == 270f)
            {
                _playerMovementInput.y = 0.1f;
            }
            else if(targetRotation == 180f ||  targetRotation == -180f)
            {
                _playerMovementInput.x = 0.1f;
            }
        }
        else if (transform.position.x < -Xrange)
        {
            if (targetRotation == -90f || targetRotation == 270f)
            {
                _playerMovementInput.y = -0.1f;
            }
            else if (targetRotation == -270f || targetRotation == 90f)
            {
                _playerMovementInput.y = 0.1f;
            }
            else if (targetRotation == 0f)
            {
                _playerMovementInput.x = 0.1f;
            }
            else if (targetRotation == 180f || targetRotation == -180f)
            {
                _playerMovementInput.x = -0.1f;
            }
        }
        else if (transform.position.z > Yrange)
        {
            if (targetRotation == 0f)
            {
                _playerMovementInput.y = -0.1f;
            }
            else if (targetRotation == 180f || targetRotation == -180f)
            {
                _playerMovementInput.y = 0.1f;
            }
            else if (targetRotation == -270f || targetRotation == 90f)
            {
                _playerMovementInput.x = 0.1f;
            }
            else if (targetRotation == -90f || targetRotation == 270f)
            {
                _playerMovementInput.x = -0.1f;
            }
        }
        else if (transform.position.z < -Yrange) 
        {
            if (targetRotation == 90f || targetRotation == -270f)
            {
                _playerMovementInput.x = -0.1f;
            }
            else if (targetRotation == -90f || targetRotation == 270f)
            {
                _playerMovementInput.x = 0.1f;
            }
            else if (targetRotation == 0f)
            {
                _playerMovementInput.y = 0.1f;
            }
            else if (targetRotation == 180f || targetRotation == -180f)
            {
                _playerMovementInput.y = -0.1f;
            }
        }

        targetRotation = GameObject.Find("CameraController").GetComponent<CameraController>().targetRotation;
        /*groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        /*

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
        //controller.Move(playerVelocity * Time.deltaTime);
    }

    void Moveplayer()
    {
        

        if (targetRotation == 0f)
        {
            Vector3 move = new Vector3(_playerMovementInput.x, 0.0f, _playerMovementInput.y);
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
        else if (targetRotation == -90f || targetRotation == 270f)
        {
            Vector3 move = new Vector3(-_playerMovementInput.y, 0.0f, _playerMovementInput.x);
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
        else if (targetRotation == -180f || targetRotation == 180f)
        {
            Vector3 move = new Vector3(-_playerMovementInput.x, 0.0f, -_playerMovementInput.y);
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
        else if (targetRotation == -270f || targetRotation == 90f)
        {
            Vector3 move = new Vector3(_playerMovementInput.y, 0.0f, -_playerMovementInput.x);
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
    }

    void OnMove(InputValue iv)
    {
        //Debug.Log("Move");
        _playerMovementInput = iv.Get<Vector2>();
    }
}