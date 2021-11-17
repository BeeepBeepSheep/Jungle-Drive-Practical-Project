using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speedState;
    public bool suspensionIsRaised;
    public bool isInMud;
    public bool exitMudRaisedFast;
    public bool canKeepMomentom;

    public float currantSpeed = 25f;
    public float minSpeed = 28f;
    public float maxSpeed = 35;
    public float mudSpeed = 15;
    public float slownessDelayAfetrMaxSpeed = 1f;
    public float speedUpDelayAfterMud = 2f;

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

    public UIManager uiManagerScript;
    //if 0 left, if 1 forward, if 2 right;
    void Start()
    {
        currantHorizontalSpeed = baseHorizontalSpeed;
        suspensionIsRaised = true;
        speedState = 0;
        car.GetComponent<BoxCollider>().material = carSuspendedPhysMat;
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
        //fix horizontalm move

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

        //SpeedManager();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SuspensionLogic();
            SpeedManager();
        }
    }
    public void SpeedManager()
    {
        if (!isInMud) // not in mud
        {
            if (!suspensionIsRaised) //not raised
            {
                StartCoroutine(AllowSpeedUp());
            }
            else // raised
            {
                if (!exitMudRaisedFast)
                {
                    StartCoroutine(SlowdownDelay());
                }
                else
                {
                    SetSpeedFast();
                }
            }
        }

        if (isInMud) // in mud
        {
            if (!suspensionIsRaised && speedState == 1) //not raised
            {
                SetSpeedMud();
            }
            else // raised
            {
                if (speedState == 1)
                {
                    SetSpeedFast();
                }
                if (speedState == 0)
                {
                    currantSpeed = minSpeed;
                }
            }
        }
    }
    void SuspensionLogic()
    {
        if (!suspensionIsRaised)
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
    public void SetSpeedFast()
    {
        currantSpeed = maxSpeed;
        speedState = 1;

        isFastCamAnim = true;
        camAnim.SetBool("isFast", isFastCamAnim);

        exitMudRaisedFast = false;
    }
    public IEnumerator AllowSpeedUp()
    {
        yield return new WaitForSeconds(speedUpDelayAfterMud);
        SetSpeedFast();
    }
    public void SetSpeedSlow()
    {
        currantSpeed = minSpeed;
        speedState = 0;
        isFastCamAnim = false;
        camAnim.SetBool("isFast", isFastCamAnim);
    }
    public void SetSpeedMud()
    {
        currantSpeed = mudSpeed;
        speedState = -1;
        isFastCamAnim = false;
        camAnim.SetBool("isFast", isFastCamAnim);
    }

    public IEnumerator SlowdownDelay()
    {
        if (!exitMudRaisedFast)
        {
            if (suspensionIsRaised)
            {
                uiManagerScript.CountDownStart(slownessDelayAfetrMaxSpeed);
                yield return new WaitForSeconds(slownessDelayAfetrMaxSpeed);
                SetSpeedSlow();
            }
        }
    }
}