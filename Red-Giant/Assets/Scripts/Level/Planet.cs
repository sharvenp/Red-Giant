using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Planet : MonoBehaviour
{
    public ObjectPool<Planet> pool;

    public UIManager UIManager;
    public LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerMask == (playerMask | (1 << other.gameObject.layer)))
        {
            UIManager.SetUIState(true);
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
