using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject retryPanel;

    private void Start()
    {
        retryPanel.SetActive(false);
    }

    public void TriggerPlayerDead()
    {
        retryPanel.SetActive(true);
    }
}
