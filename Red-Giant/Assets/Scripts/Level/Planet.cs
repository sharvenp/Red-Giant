using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Planet : MonoBehaviour
{
    public ObjectPool<Planet> pool;

    public UIManager UIManager;
    public LayerMask playerMask;
    public LayerMask sunMask;
    public float destroyTime = 5.0f;

    private float destroyTimer;
    private bool isDestroyed;

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed)
        {
            destroyTimer -= Time.deltaTime;
            if (destroyTimer < 0)
            {
                isDestroyed = false;
                pool.Release(this);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerMask == (playerMask | (1 << other.gameObject.layer)))
        {
            UIManager.SetUIState(true);
        }
        if (sunMask == (sunMask | (1 << other.gameObject.layer)))
        {
            isDestroyed = true;
            destroyTimer = destroyTime;
            pool.Get();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerMask == (playerMask | (1 << other.gameObject.layer)))
        {
            UIManager.SetUIState(false);
        }
    }
}
