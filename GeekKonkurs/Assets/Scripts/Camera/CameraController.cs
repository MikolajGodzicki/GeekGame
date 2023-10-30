using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Direction direction = Direction.Forward;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            SetDirection(-1);
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.RightArrow)) {
            SetDirection(1);
        }

        switch (direction) {
            case Direction.Forward:
                transform.eulerAngles = new Vector3();
                break;
            case Direction.Right:
                transform.eulerAngles = new Vector3(0f, 270f);
                break;
            case Direction.Backward:
                transform.eulerAngles = new Vector3(0f, 180f);
                break;
            case Direction.Left:
                transform.eulerAngles = new Vector3(0f, 90f);
                break;
        }

    }

    private void SetDirection(int direction) {
        if (this.direction + direction < 0) {
            this.direction = Direction.Left;
            return;
        }
        if (this.direction + direction > Direction.Max - 1) {
            this.direction = Direction.Forward;
            return;
        }

        this.direction += direction;
    }
}

public enum Direction {
    Forward,
    Right,
    Backward,
    Left,

    Max,
}
