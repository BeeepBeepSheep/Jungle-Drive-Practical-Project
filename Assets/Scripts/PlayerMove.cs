using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float currantSpeed = 10f;
    public Rigidbody rb;
    float steering;
    public float steeringSpeed = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = transform.forward * (currantSpeed);

        steering += Input.GetAxis("Mouse X") * steeringSpeed;
        transform.rotation = Quaternion.Euler(transform.rotation.y, steering, 0f);
    }
}
