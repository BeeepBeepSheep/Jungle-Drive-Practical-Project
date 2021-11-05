using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float currantSpeed = 10f;
    public Rigidbody rb;
    float steeringInput;

    public float maxSteer = 25f;
    public float minSteer = -25f;

    public GameObject car;

    public float steeringSpeed = 3f;

    void Update()
    {
        rb.velocity = car.transform.forward * (currantSpeed);

        steeringInput += Input.GetAxis("Mouse X") * steeringSpeed;
        car.transform.rotation = Quaternion.Euler(transform.rotation.y, steeringInput, 0f);
    }
}
