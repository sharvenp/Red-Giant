using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{
    public float pitchPower, rollPower, yawPower, enginePower;

    public float rollAcceleration = 2f;
    public float pitchAcceleration = 2f;
    public float yawAcceleration = 2f;

    private float activeRoll, activePitch, activeYaw;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float engine = 0f;

        if (Input.GetKey(KeyCode.Space))
        {
            engine = enginePower;
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            engine = -enginePower;
        }

        rb.AddForce(transform.forward * engine * Time.deltaTime);

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        float yaw = Input.GetAxisRaw("Yaw");

        activePitch = Mathf.Lerp(activePitch, vertical * pitchPower, pitchAcceleration * Time.deltaTime);
        activeRoll = Mathf.Lerp(activeRoll, horizontal * rollPower, rollAcceleration * Time.deltaTime);
        activeYaw = Mathf.Lerp(activeYaw, yaw * yawPower, yawAcceleration * Time.deltaTime);

        transform.Rotate(activePitch * pitchPower * Time.deltaTime, 
                            activeYaw * yawPower * Time.deltaTime,
                            -activeRoll * rollPower * Time.deltaTime);

    }
}
