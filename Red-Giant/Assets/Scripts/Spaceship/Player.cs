using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.UI;
using TMPro;
using Unity.Burst.CompilerServices;

public class Player : MonoBehaviour
{
    public float pitchPower, rollPower, yawPower, enginePower;

    public float maxFuel = 100f;
    public float drainRate = 0.5f;
    public Image fuelImage;
    public float rollAcceleration = 2f;
    public float pitchAcceleration = 2f;
    public float yawAcceleration = 2f;

    public ParticleSystem[] backExhausts;
    public ParticleSystem[] frontExhausts;

    public AudioSource thursterAudio;

    public TextMeshProUGUI speedText;

    private float activeRoll, activePitch, activeYaw;
    Rigidbody rb;

    private float fuel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateExhausts(backExhausts, false);
        UpdateExhausts(frontExhausts, false);
        fuelImage.fillAmount = 1;
        fuel = maxFuel;
    }

    public float GetFuel()
    {
        return fuel;
    }

    public void Refuel(float fuelAmount)
    {
        fuel += fuelAmount;
        fuel = Mathf.Clamp(fuel, 0, maxFuel);
        Debug.Log(fuel);
    }

    private void UpdateExhausts(ParticleSystem[] exhausts, bool isOn)
    {
        foreach(var exhaust in exhausts)
        {
            if (isOn && !exhaust.isPlaying)
            {
                exhaust.Play();
                thursterAudio.Play();
            }
            else if (!isOn && exhaust.isPlaying)
            {
                thursterAudio.Pause();
                exhaust.Stop();
            }
        }
    }

    private void Update()
    {
        float engine = 0f;

        if (Input.GetKey(KeyCode.Space) && fuel > 0f)
        {
            engine = enginePower;
            UpdateExhausts(backExhausts, true);
        }

        if (Input.GetKey(KeyCode.LeftControl) && fuel > 0f)
        {
            engine = -enginePower;
            UpdateExhausts(frontExhausts, true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            UpdateExhausts(backExhausts, false);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            UpdateExhausts(frontExhausts, false);
        }

        if (engine != 0f)
        {
            fuel -= drainRate * Time.deltaTime;
            fuel = Mathf.Clamp(fuel, 0f, maxFuel);
        }
        fuelImage.fillAmount = (fuel / maxFuel);

        if (fuel == 0f)
        {
            UpdateExhausts(backExhausts, false);
            UpdateExhausts(frontExhausts, false);
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

        float speed = rb.velocity.magnitude;
        string speedString = speed.ToString("0.00");
        speedText.text = $"{speedString} KM/S";
    }
}
