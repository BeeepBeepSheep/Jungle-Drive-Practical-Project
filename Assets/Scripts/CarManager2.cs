using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarManager2 : MonoBehaviour
{
    public float maxXRotation = 45f;
    public float minXRotation = -45f;
    public float currantXRotation;

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

        RotationManagerOther();
    }

    void LateUpdate()
    {
        RotationManagerY();
    }

    void TurnWheel(float currantWheelTurnSpeed)
    {
        backWheels.Rotate(Vector3.left * Time.deltaTime * currantWheelTurnSpeed);
        frontRightWheel.Rotate(Vector3.left * Time.deltaTime * currantWheelTurnSpeed);
        frontLeftWheel.Rotate(Vector3.left * Time.deltaTime * currantWheelTurnSpeed);

        driveShaft.Rotate(Vector3.down * Time.deltaTime * currantWheelTurnSpeed / 2);
    }

    public void SuspensionManager()
    {
        frontLeftSuspension.LookAt(frontLeftSuspensionTarget);
        frontRightSuspension.LookAt(frontRightSuspensionTarget);
        backLeftSuspension.LookAt(backLeftSuspensionTarget);
        backRightSuspension.LookAt(backRightSuspensionTarget);
    }

    void RotationManagerY()
    {
        //fix y rotation
        if (transform.rotation.y != 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        }
    }
    void RotationManagerOther()
    {
        currantXRotation = transform.rotation.x * 100;
        currantZRotation = transform.rotation.z * 100;

        // x rotation
        if (currantXRotation < minXRotation)
        {
            //Debug.Log("x");

            transform.localEulerAngles = new Vector3(minXRotation, 0, transform.localEulerAngles.z);
        }
        else if (currantXRotation > maxXRotation)
        {
            //Debug.Log("x");

            transform.localEulerAngles = new Vector3(maxXRotation, 0, transform.localEulerAngles.z);
        }

        //z rotation
        if (currantZRotation < minZRotation)
        {
            //Debug.Log("z");
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        }
        else if (currantZRotation > maxZRotation)
        {
            //Debug.Log("z");
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, minZRotation);
        }
    }
}