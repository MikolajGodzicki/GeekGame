using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeviceDetector : MonoBehaviour
{
    public GameObject keyboard;
    public GameObject controller;

    private void Start()
    {
        //keyboard = GetComponent<CharacterController>();
        //controller = GetComponent<CharacterController>();
    }

    void Update()
    {

    }

    void OnKeybord(InputValue iv)
    {
        Debug.Log("Keyborad");
        keyboard.SetActive(true);
        controller.SetActive(false);
    }

    void OnController(InputValue iv)
    {
        Debug.Log("Gamepad");
        keyboard.SetActive(false);
        controller.SetActive(true);
    }
}
