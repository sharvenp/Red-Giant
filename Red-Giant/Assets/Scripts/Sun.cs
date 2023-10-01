using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    private float start_time;
    private float lerp_time = 0f;

    public float growth_rate = 0.5f;
    Material myMaterial;
    Renderer rend;

    float interval = 2.0f;
    public Color colorStart = Color.yellow;
    public Color color2 = Color.red;

    private int curr_color = 0;
    public Color[] colors = { Color.yellow, Color.red, Color.blue, Color.black };
    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;

        myMaterial = GetComponent<Renderer>().material;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(growth_rate, growth_rate, growth_rate) * Time.deltaTime;

        if (curr_color != colors.Length - 1)
        {
            if (Time.time - start_time < interval)
            {
                //float lerp = Mathf.PingPong(Time.time, interval) / interval;
                float lerp = Mathf.Lerp(0, interval, lerp_time);
                lerp_time += Time.deltaTime;
                rend.material.color = Color.Lerp(colors[curr_color], colors[curr_color + 1], lerp);
            } else
            {
                start_time = Time.time;
                lerp_time = 0f;
                curr_color++;
            }
        }

    }
}
