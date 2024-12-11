using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

// Allan Le Mans - 07/12/2024 Vehicle Control Physics

public class movement : MonoBehaviour
{
    Rigidbody body;

    public float topSpeed = 300f; // Units are km/h.
    public float fromZeroToMax = 13.6f; // 13.6 seconds to max speed.
    public float fromMaxToZero = 24.6f;
    public float timeBrakeToZero = 2f;

    public float acceleration;
    public float decceleration;
    public float forwardVelocity;
    public float brakeRate;
   
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        forwardVelocity = 0f;
 
        acceleration = topSpeed / fromZeroToMax;
        decceleration = -topSpeed / fromMaxToZero;
        brakeRate = topSpeed / timeBrakeToZero;

    }

    float Accelerate()
    {
        forwardVelocity += acceleration * Time.deltaTime;
        forwardVelocity = Mathf.Min(forwardVelocity, topSpeed);

       
        
        Debug.Log(forwardVelocity);
        return forwardVelocity;
    
    }
    float Deccelerate()
    {
        forwardVelocity += decceleration * Time.deltaTime;
        return 0;

    }
    float Brake()
    {
        forwardVelocity -= brakeRate * Time.deltaTime;
        forwardVelocity = Mathf.Max(forwardVelocity, 0);
        return 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Accelerate();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Deccelerate();
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            Brake();
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.transform.Rotate(0, -1, 0); // This isn't the right way of doing this.

        }
        if (Input.GetKey(KeyCode.D))
        {
            body.transform.Rotate(0, 1, 0);
        }
    }
    private void LateUpdate()
    {
        body.velocity = transform.forward * forwardVelocity;
    }
}
