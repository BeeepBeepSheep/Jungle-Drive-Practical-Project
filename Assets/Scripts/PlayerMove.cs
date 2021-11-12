using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float currantSpeed = 25f;
    public float currantHorizontalSpeed = 25f;
    public float baseHorizontalSpeed = 25f;
    public Rigidbody rb;
    float horizontalInput;

    public Transform car;
    public Transform carPosition;

    public Animator carAnim;

    public int turnStateInt = 1;

    //if 0 left, if 1 forward, if 2 right;
    void Start()
    {
        currantHorizontalSpeed = baseHorizontalSpeed;
    }
    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * currantSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * currantHorizontalSpeed * Time.fixedDeltaTime;
        
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        carAnim.SetInteger("TurnStateInt", turnStateInt);
        InputManagment();

        //fix horizontalm ove
        if (turnStateInt == 2)
        {
            currantHorizontalSpeed = 0;
        }
        else
        {
            currantHorizontalSpeed = baseHorizontalSpeed;
        }

        //car height
        car.position = new Vector3(carPosition.position.x, car.position.y, carPosition.position.z);
    }
    void InputManagment()
    {
        //normalize
        if (Input.GetKeyUp("a"))
        {
            turnStateInt = 2;
        }
        if (Input.GetKeyUp("d"))
        {
            turnStateInt = 2;
        }
        if (Input.GetKey("a") && Input.GetKey("b"))
        {
            turnStateInt = 2;
        }
        //left
        if (Input.GetKey("a"))
        {
            turnStateInt = 0;
            if (Input.GetKey("d"))
            {
                turnStateInt = 2;
            }
        }

        //right
        if (Input.GetKey("d"))
        {
            turnStateInt = 3;
            if (Input.GetKey("a"))
            {
                turnStateInt = 2;
            }
        }
    }
}
//mouse steer

//steeringInput += Input.GetAxis("Mouse X") * steeringSpeed;
//car.transform.rotation = Quaternion.Euler(transform.rotation.y, steeringInput, 0f);
