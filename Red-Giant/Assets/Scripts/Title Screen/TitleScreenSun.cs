using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenSun : MonoBehaviour
{

    public float noiseIntensity;
    public float rate;

    private Vector3 startScale;
    private Vector3 startPosition;
    private float timeTillLastUpdate = 0f;

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void Update()
    {
        if (Time.time >= timeTillLastUpdate)
        {
            timeTillLastUpdate = Time.time + rate * Random.Range(0f, 3f);

            float x = Random.Range(-1f, 1f) * noiseIntensity;
            float y = Random.Range(-1f, 1f) * noiseIntensity;
            float z = Random.Range(-1f, 1f) * noiseIntensity;

            Vector3 noise = new(x, y, z);
            transform.localScale = startScale + noise;

            transform.position = startPosition + noise;
        }
    }
}
