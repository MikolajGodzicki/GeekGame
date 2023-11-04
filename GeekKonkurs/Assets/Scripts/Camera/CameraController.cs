using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    LookToCamera lookToCamera;
    public float rotationSpeed = 135f;
    public float smoothTime = 0.2f;
    public float targetRotation = 0;
    private Quaternion initialRotation;
    public Quaternion targetQuaternion;
    public GameObject InstanceToFollow;
    public float cameraSpeed = 8.0f;

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
        lookToCamera = GameObject.FindGameObjectWithTag("LookToCamera").GetComponent<LookToCamera>();
        StartCoroutine(ToCamera());
    }

    IEnumerator ToCamera(){
          yield return new WaitForSeconds(1);
          lookToCamera.StartRotating();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            targetRotation += 90f;
            if (targetRotation >= 360) {
                targetRotation = 0;
            }
            StartCoroutine(ToCamera());
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.RightArrow)) {
            targetRotation -= 90f;
            if (targetRotation <= -360) {
                targetRotation = 0;
            }
            StartCoroutine(ToCamera());
        }

        direction = directions[targetRotation];
        //Debug.Log(direction);

        targetQuaternion = Quaternion.Euler(45, targetRotation, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, smoothTime * rotationSpeed * Time.deltaTime);


        float Interpolation = cameraSpeed * Time.deltaTime;

        Vector3 position = transform.position;

        if(targetRotation == 0f){
            position.y = Mathf.Lerp(transform.position.y, (InstanceToFollow.transform.position.y)-1, Interpolation);
            position.x = Mathf.Lerp(transform.position.x, InstanceToFollow.transform.position.x, Interpolation);
            position.z = Mathf.Lerp(transform.position.z, (InstanceToFollow.transform.position.z)-2, Interpolation);
        }else if(targetRotation == -90f || targetRotation == 270f){
            position.y = Mathf.Lerp(transform.position.y, (InstanceToFollow.transform.position.y)-1, Interpolation);
            position.x = Mathf.Lerp(transform.position.x, (InstanceToFollow.transform.position.x)+2, Interpolation);
            position.z = Mathf.Lerp(transform.position.z, InstanceToFollow.transform.position.z, Interpolation);
        }else if(targetRotation == -180f || targetRotation == 180f){
            position.y = Mathf.Lerp(transform.position.y, (InstanceToFollow.transform.position.y)-1, Interpolation);
            position.x = Mathf.Lerp(transform.position.x, InstanceToFollow.transform.position.x, Interpolation);
            position.z = Mathf.Lerp(transform.position.z, (InstanceToFollow.transform.position.z)+2, Interpolation);
        }else if(targetRotation == -270f || targetRotation == 90f){
            position.y = Mathf.Lerp(transform.position.y, (InstanceToFollow.transform.position.y)-1, Interpolation);
            position.x = Mathf.Lerp(transform.position.x, (InstanceToFollow.transform.position.x)-2, Interpolation);
            position.z = Mathf.Lerp(transform.position.z, InstanceToFollow.transform.position.z, Interpolation);
        }

        transform.position = position;
        
    }
}

public enum Direction {
    Forward,
    Backward,
    Left,
    Right
}
