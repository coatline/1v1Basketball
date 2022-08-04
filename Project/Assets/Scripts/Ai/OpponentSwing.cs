using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSwing : MonoBehaviour
{

    HingeJoint2D hj;
    bool swingingUp;
    float timer;
    bool colliding;
    int transition = 2;
    bool swingingDown;
    bool done;


    private void Awake()
    {
        hj = GetComponent<HingeJoint2D>();
    }

    private void FixedUpdate()
    {
        //hj.connectedAnchor = new Vector2(-0.03671439f, .04934936f);
        //hj.anchor = new Vector2(-0.05139986f, 0.008040165f);
        if (!swingingUp)
        {

            var m = hj.motor;
            m.motorSpeed = 0;
            hj.motor = m;

            Vector3 origonal = new Vector3(0, 180, 224.77f);

            transform.rotation = Quaternion.Euler(origonal);

        }

        /*
         * 
            var m = hj.motor;
            m.motorSpeed = 0;
            hj.motor = m;

            var transition = 2;

            Vector3 origonal = new Vector3(0, 180, 224.77f) / transition;

            transform.rotation = Quaternion.Euler(origonal);

            transition++;
        */

        if (swingingUp)
        {
            var m = hj.motor;
            m.motorSpeed = 900;
            hj.motor = m;
        }
        //if (swingingDown)
        //{

        //    float downTimer = 0;
        //    downTimer += .01f;
        //    Debug.Log(downTimer);

        //    if(downTimer >= .2f)
        //    {
        //        done = true;
        //        var m = hj.motor;
        //        m.motorSpeed = 0;
        //        hj.motor = m;
        //        swingingDown = false;
        //        Debug.Log("DONE SWINGING!");
        //        done = false;
        //    }

        //    if (downTimer < .2f && !done)
        //    {
        //        var m = hj.motor;
        //        m.motorSpeed = 400;
        //        hj.motor = m;
        //    }


        //}


        //swinging up
        if (timer < .24f && swingingUp)
        {
            timer += Time.fixedDeltaTime;
        }
        
        //swinging back down
        if (timer >= .24f)
        {
            //swingingDown = true;
            timer = 0;
            //done = true;
            swingingUp = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            swingingUp = true;
        }
    }
}
