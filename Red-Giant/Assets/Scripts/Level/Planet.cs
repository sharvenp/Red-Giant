using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Planet : MonoBehaviour
{
    public ObjectPool<Planet> pool;

    public LayerMask playerMask;
    public LayerMask sunMask;
    public float destroyTime = 5.0f;
    public float refuelAmount;

    public AudioClip refuelSound;

    private float destroyTimer;
    private bool isDestroyed;

    private void OnEnable()
    {
        if (gameObject.tag == "Planet")
        {
            Renderer[] rend = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rend)
            {
                Color c = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f);
                r.material.color = c;
                r.material.SetColor("_EmissionColor", c * Random.Range(0.2f, 2f));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed)
        {
            destroyTimer -= Time.deltaTime;
            if (destroyTimer < 0)
            {
                isDestroyed = false;
                pool?.Release(this);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerMask == (playerMask | (1 << other.gameObject.layer)))
        {
            if (gameObject.tag == "Astroid")
            {
                other.transform.parent.gameObject.GetComponent<Player>().Refuel(refuelAmount);
                other.transform.parent.gameObject.GetComponent<AudioSource>().PlayOneShot(refuelSound);
                isDestroyed = true;
                pool?.Get();
            }
        }

        if (sunMask == (sunMask | (1 << other.gameObject.layer)))
        {
            isDestroyed = true;
            destroyTimer = destroyTime;
            pool?.Get();
        }
    }

}
