using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject autoLandButton;
    public GameObject resourcesButton;

    private void Start()
    {
        autoLandButton.SetActive(false);
        resourcesButton.SetActive(false);
    }

    public void SetUIState(bool state)
    {
        autoLandButton.SetActive(state);
        resourcesButton.SetActive(state);
    }
}
