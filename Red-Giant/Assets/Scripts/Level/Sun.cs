using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Material material;
    private float next_time;
    public float color_update_interval = 0.1f;

    public float color_mix_rate = 0.1f;
    private float color_mix = 0f;
    public float hold_color = 5.0f;

    public float growth_rate = 0.5f;
    Renderer rend;

    private int curr_color = 0;
    public Color[] colors = { Color.yellow, Color.red, Color.blue, Color.black };
    // Start is called before the first frame update
    void Start()
    {
        next_time = Time.time;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(growth_rate, growth_rate, growth_rate) * Time.deltaTime;

        if (curr_color != colors.Length - 1)
        {
            if (Time.time > next_time)
            {
                next_time = Time.time + color_update_interval;
                color_mix += Time.deltaTime * color_mix_rate;
                if (color_mix >= 1)
                {
                    color_mix = 0;
                    curr_color += 1;

                    next_time = Time.time + hold_color;
                }
                material.color = Color.Lerp(colors[curr_color], colors[curr_color + 1], color_mix);
                material.SetColor("_EmissionColor", Color.Lerp(colors[curr_color], colors[curr_color + 1], color_mix));
            }
        }

    }
}
