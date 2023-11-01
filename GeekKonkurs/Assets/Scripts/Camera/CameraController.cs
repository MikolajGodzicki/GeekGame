using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float smoothTime = 0.3f;
    private float targetRotation = 0;
    private Quaternion initialRotation;
    private Quaternion targetQuaternion;

    private Dictionary<float, Direction> directions = new Dictionary<float, Direction>() {
        { 0f, Direction.Forward },
        { 90f, Direction.Left },
        { 180f, Direction.Backward },
        { 270f, Direction.Right },
        { -90f, Direction.Right },
        { -180f, Direction.Backward },
        { -270f, Direction.Left },
    };

    private Direction direction;

    private void Start() {
        initialRotation = transform.rotation;
        targetQuaternion = initialRotation;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            targetRotation += 90f;
            if (targetRotation >= 360) {
                targetRotation = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.RightArrow)) {
            targetRotation -= 90f;
            if (targetRotation <= -360) {
                targetRotation = 0;
            }
        }

        direction = directions[targetRotation];
        Debug.Log(direction);

        targetQuaternion = Quaternion.Euler(0, targetRotation, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, smoothTime * rotationSpeed * Time.deltaTime);
    }
}

public enum Direction {
    Forward,
    Backward,
    Left,
    Right
}
