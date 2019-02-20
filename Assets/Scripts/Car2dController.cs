﻿using UnityEngine;
using System.Collections;

public class Car2dController : MonoBehaviour
{
    float speedForce = 10f;
    float torqueForce = -200f;
    float driftFactorSticky = 0.9f;
    float driftFactorSlippy = 1f;
    float maxStickyVelocity = 2.5f;
   
    // Use this for initialization
    void Start()
    {
    }
        void Update(){
        }

    

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Debug.Log(RightVelocity().magnitude);

        float driftFactor = driftFactorSticky;
        if(RightVelocity().magnitude> maxStickyVelocity){
            driftFactor = driftFactorSlippy;
        }



        rb.velocity = ForwardVelocity()+ RightVelocity()*driftFactor;

        if (Input.GetButton("Accelerate")){
        rb.AddForce(transform.up* speedForce);

        }
        if(Input.GetButton("Brakes")){
            rb.AddForce(transform.up * -speedForce / 2f);
        }


        float tf = Mathf.Lerp(0,torqueForce, rb.velocity.magnitude/2);

        rb.angularVelocity=Input.GetAxis("Horizontal") * tf;
    }

    Vector2 ForwardVelocity(){
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);

    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);

    }
}
