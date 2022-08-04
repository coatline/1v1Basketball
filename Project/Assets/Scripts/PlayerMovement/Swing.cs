using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] float swingRecoilSpeed;
    [SerializeField] float swingSpeed;
    HingeJoint2D hj;
    Rigidbody2D rb;

    void Awake()
    {
        hj = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    bool pressed;

    void FixedUpdate()
    {
        if (pressed)
        {
            if (hj.limitState == JointLimitState2D.LowerLimit)
            {
                hj.useMotor = false;
                rb.freezeRotation = true;
            }
            else
            {
                rb.freezeRotation = false;
                hj.useMotor = true;
                var newMSettings = hj.motor;
                newMSettings.motorSpeed = -swingSpeed;
                hj.motor = newMSettings;
            }
        }
        else if (!pressed)
        {
            if (hj.limitState == JointLimitState2D.UpperLimit)
            {
                hj.useMotor = false;
                rb.freezeRotation = true;
            }
            else
            {
                rb.freezeRotation = false;
                hj.useMotor = true;
                var newMSettings = hj.motor;
                newMSettings.motorSpeed = swingRecoilSpeed;
                hj.motor = newMSettings;
            }
        }

        //if (pressed)
        //{
        //    if(hj.motor.motorSpeed != -900)
        //    {
        //        rb.freezeRotation = false;
        //        rb.angularVelocity = 0;
        //        var m = hj.motor;
        //        m.motorSpeed = -900;
        //        m.maxMotorTorque = 100000;
        //        hj.motor = m;
        //    }
        //    else if(hj.limitState == JointLimitState2D.LowerLimit)
        //    {
        //        hj.useMotor = false;
        //        rb.freezeRotation = true;
        //    }
        //}
        //else if (!pressed)
        //{
        //    if (hj.motor.motorSpeed != 1500)
        //    {
        //        rb.freezeRotation = false;
        //        rb.angularVelocity = 0;
        //        hj.motor = new JointMotor2D() { motorSpeed = 1500, maxMotorTorque = 100000 };
        //    }
        //    else if (hj.limitState == JointLimitState2D.UpperLimit)
        //    {
        //        hj.useMotor = false;
        //        rb.freezeRotation = true;
        //    }
        //}
    }

    void Update()
    {
        pressed = Input.GetKey(KeyCode.Space);
    }
}
