using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public Text SpeedText;
    public Text TimeText;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float brakeForce;
    [SerializeField] private float turnSpeed;

    private Rigidbody rb;
    private bool isAccelerating = false;
    private bool isSpeedUp = false;
    private bool isSpeedDown = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (CrossScene.isFiatSelected)
        {
            transform.Find("FIAT").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("Mustang").gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAccelerating && isSpeedUp)
        {
            rb.AddForce(transform.forward * forwardSpeed, ForceMode.Acceleration);
        }
        else if(isAccelerating && isSpeedDown)
        {
            rb.AddForce(transform.forward * -forwardSpeed, ForceMode.Acceleration);
        }

        UpdateUIText();

    }

    private void UpdateUIText()
    {
        SpeedText.text = "Speed: " + Mathf.Round(rb.velocity.magnitude);
        TimeText.text = "Time: " + Mathf.Round(Time.timeSinceLevelLoad);
    }

    public void TurnRight()
    {
        rb.AddTorque(transform.up * turnSpeed * 1);
    }
    public void TurnLeft()
    {
        rb.AddTorque(transform.up * turnSpeed * -1);
    }
    public void AccelerateOn()
    {
        isAccelerating = true;
    }
    public void AccelerateOff()
    {
        isAccelerating = false;
    }

    public void Brake()
    {
        rb.AddForce(-brakeForce * rb.velocity);
    }

    public void SpeedUp()
    {
        isSpeedUp = true;
        isSpeedDown = false;
    }

    public void SpeedDown()
    {
        isSpeedDown = true;
        isSpeedUp = false;
    }
}
