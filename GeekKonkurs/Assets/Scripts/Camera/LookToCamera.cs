using System.Collections;
using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    private float rotationSpeed;
    private float smoothTime;
    private float targetRotation;
    private Quaternion targetQuaternion;
    public Transform Target;
    public float Speed = 1f;

    private Coroutine LookCoroutine;

    private void Update(){
        rotationSpeed = GameObject.Find("CameraController").GetComponent<CameraController>().rotationSpeed;
        smoothTime = GameObject.Find("CameraController").GetComponent<CameraController>().smoothTime;
        targetRotation = GameObject.Find("CameraController").GetComponent<CameraController>().targetRotation;
    }
    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        float time = 0;

         targetQuaternion = Quaternion.Euler(-90, targetRotation, 0);
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, smoothTime * rotationSpeed * Time.deltaTime);

            time += Time.deltaTime * Speed;

            yield return null;
        }
    }
}