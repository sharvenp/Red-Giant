using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public UIManager UIManager;
    public LayerMask playerMask;


    private void OnTriggerEnter(Collider other)
    {
        if (playerMask == (playerMask | (1 << other.gameObject.layer)))
        {
            UIManager.SetStateAutoLandButton(true);
            UIManager.SetStateResoucesButton(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerMask == (playerMask | (1 << other.gameObject.layer)))
        {
            UIManager.SetStateAutoLandButton(false);
            UIManager.SetStateResoucesButton(false);
        }
    }
}
