using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float currantSpeed = 25f;
    public float minSpeed = 25f;
    public float maxSpeed = 35;
    public int speedState;

    public bool suspensionIsRaised;
    public PhysicMaterial carSuspendedPhysMat;

    public float currantHorizontalSpeed = 25f;
    public float baseHorizontalSpeed = 25f;
    float horizontalInput;
    public Rigidbody rb;

    public Transform car;
    public Transform carPosition;

    public Animator camAnim;
    bool isFastCamAnim;

    public Animator carAnim;

    public int turnStateInt = 1;

    //if 0 left, if 1 forward, if 2 right;
    void Start()
    {
        currantHorizontalSpeed = baseHorizontalSpeed;
        suspensionIsRaised = true;
        speedState = 0;
    }
    void FixedUpdate()
    {
        //move
        Vector3 forwardMove = transform.forward * currantSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * currantHorizontalSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //carAnim.SetInteger("TurnStateInt", turnStateInt);
        carAnim.SetBool("suspensionIsRaised", suspensionIsRaised);

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

        //car height physics
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

        //suspension
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SuspensionLogic();
            SpeedManager();
        }
    }
    void SpeedManager()
    {
        if(!suspensionIsRaised)
        {
            //fast
            currantSpeed = maxSpeed;
            speedState = 1;

            isFastCamAnim = true;
            camAnim.SetBool("isFast", isFastCamAnim);

        }
        else
        {
            //slow
            currantSpeed = minSpeed;
            speedState = 0;

            isFastCamAnim = false;
            camAnim.SetBool("isFast", isFastCamAnim);

        }
    }
    void SuspensionLogic()
    {
        if(!suspensionIsRaised)
        {
            //rais
            suspensionIsRaised = true;
            car.GetComponent<BoxCollider>().material = carSuspendedPhysMat;
        }
        else
        {
            //lower
            suspensionIsRaised = false;
            car.GetComponent<BoxCollider>().material = null;
        }
    }
}