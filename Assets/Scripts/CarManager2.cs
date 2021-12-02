using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager2 : MonoBehaviour
{
    public float maxXRotation = 45f;
    public float minXRotation = -90f;
    public float currantXRotation;

    public float maxYRotation = 0f;
    public float minYRotation = 0f;
    public float currantYRotation;

    public float maxZRotation = 20f;
    public float minZRotation = -20f;
    public float currantZRotation;

    public Transform backWheels;
    public Transform frontRightWheel;
    public Transform frontLeftWheel;
    public Transform driveShaft;
    public float wheelTurnSpeedMedium = 200f;
    public float wheelTurnSpeedFast = 300f;
    public PlayerMove playerMoveScript;

    public float steerAmountDegree = 30;
    public Transform rightSteerPoint;
    public Transform leftSteerPoint;

    public Transform frontLeftSuspensionTarget;
    public Transform frontRightSuspensionTarget;
    public Transform backLeftSuspensionTarget;
    public Transform backRightSuspensionTarget;
    public Transform frontLeftSuspension;
    public Transform frontRightSuspension;
    public Transform backLeftSuspension;
    public Transform backRightSuspension;

    void Update()
    {
        //suspension
        SuspensionManager();

        //wheel speed
        if (playerMoveScript.speedState == 1)
        {
            TurnWheel(wheelTurnSpeedFast);
        }
        else
        {
            TurnWheel(wheelTurnSpeedMedium);
        }
    }

    void LateUpdate()
    {
        RotationManager();
    }
    void TurnWheel(float currantWheelTurnSpeed)
    {
        backWheels.Rotate(Vector3.left * Time.deltaTime * currantWheelTurnSpeed);
        frontRightWheel.Rotate(Vector3.left * Time.deltaTime * currantWheelTurnSpeed);
        frontLeftWheel.Rotate(Vector3.left * Time.deltaTime * currantWheelTurnSpeed);

        driveShaft.Rotate(Vector3.down * Time.deltaTime * currantWheelTurnSpeed / 2);
    }

    void SuspensionManager()
    {
        frontLeftSuspension.LookAt(frontLeftSuspensionTarget);
        frontRightSuspension.LookAt(frontRightSuspensionTarget);
        backLeftSuspension.LookAt(backLeftSuspensionTarget);
        backRightSuspension.LookAt(backRightSuspensionTarget);
    }

    void RotationManager()
    {
        //fix y rotation
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
    }
}