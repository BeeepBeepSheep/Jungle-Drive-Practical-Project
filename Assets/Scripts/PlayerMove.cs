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

    public bool canMoveLeft;
    public bool canMoveRight;
    public float maxRightMove;
    public float maxLeftMove;

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
    public Animator steerAnim;
    public int turnStateInt = 1; //if 0 left, if 1 forward, if 2 right;

    public UIManager uiManagerScript;

    public Transform tileHolder;

    public Score scoreScript;
    public EngineOverheat engineHeatScript;

    void Start()
    {
        currantHorizontalSpeed = baseHorizontalSpeed;
        suspensionIsRaised = true;
        speedState = 0;
        car.GetComponent<BoxCollider>().material = carSuspendedPhysMat;

        car.position = new Vector3(carPosition.position.x, carPosition.position.y, carPosition.position.z);
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
        InputManagment();

        horizontalInput = Input.GetAxis("Horizontal");
        carAnim.SetBool("suspensionIsRaised", suspensionIsRaised);

        //fix horizontalm move
        if (turnStateInt == 1)
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
        //horizontal

        //bounds
        if (transform.position.x < maxRightMove && Input.GetKey("d"))
        {
            //right
            turnStateInt = 2;
            if (Input.GetKey("a"))
            {
                turnStateInt = 1;
            }
        }
        
        if (transform.position.x > maxLeftMove && Input.GetKey("a"))
        {
            //left
            turnStateInt = 0;
            if (Input.GetKey("d"))
            {
                turnStateInt = 1;
            }
        }
        
        //normalize horizontal
        if (Input.GetKeyUp("a"))
        {
            turnStateInt = 1;
        }
        if (Input.GetKeyUp("d"))
        {
            turnStateInt = 1;
        }
        if (Input.GetKey("a") && Input.GetKey("b"))
        {
            turnStateInt = 1;
        }

        //to far right
        if(transform.position.x > maxRightMove)
        {
            turnStateInt = 1;
            //left
            if (Input.GetKey("a"))
            {
                turnStateInt = 0;
            }
        }

        //to far left
        if (transform.position.x < maxLeftMove)
        {
            turnStateInt = 1;
            //right
            if (Input.GetKey("d"))
            {
                turnStateInt = 2;
            }
        }

        //suspension & speed
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

        //scoreScript.StartStopWatch();
        engineHeatScript.carIsFast = true;
    }
    public IEnumerator AllowSpeedUp()
    {
        uiManagerScript.CountDownStart(speedUpDelayAfterMud);
        yield return new WaitForSeconds(speedUpDelayAfterMud);
        SetSpeedFast();
    }
    public void SetSpeedSlow()
    {
        currantSpeed = minSpeed;
        speedState = 0;
        isFastCamAnim = false;
        camAnim.SetBool("isFast", isFastCamAnim);

        //scoreScript.StopStopWatch();
        engineHeatScript.carIsFast = false;
    }
    public void SetSpeedMud()
    {
        currantSpeed = mudSpeed;
        speedState = -1;
        isFastCamAnim = false;
        camAnim.SetBool("isFast", isFastCamAnim);

        //scoreScript.StopStopWatch();
        engineHeatScript.carIsFast = false;
    }

    public IEnumerator SlowdownDelay()
    {
        if (!exitMudRaisedFast)
        {
            uiManagerScript.CountDownStart(slownessDelayAfetrMaxSpeed);
            // put slodown in ui script for better results
            yield return new WaitForSeconds(slownessDelayAfetrMaxSpeed);
            if (suspensionIsRaised)
            {
                //uiManagerScript.CountDownStart(slownessDelayAfetrMaxSpeed);
                SetSpeedSlow();
            }
        }
    }
}