using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject retryPanel;
    public GameObject sunDistanceText;

    private void Start()
    {
        sunDistanceText.SetActive(true);
        retryPanel.SetActive(false);
    }

    public void TriggerPlayerDead()
    {
        sunDistanceText.SetActive(false);
        retryPanel.SetActive(true);
    }
}
