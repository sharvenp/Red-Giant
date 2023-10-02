using TMPro;
using UnityEngine;

public class SunDistance : MonoBehaviour
{

    public Transform player;
    public Transform sun;

    public LayerMask sunMask;

    public TextMeshProUGUI distanceText;

    private void Update()
    {
        if(Physics.Linecast(player.position, sun.position, out RaycastHit hit, sunMask))
        {
            float distance = hit.distance;
            string distString = distance.ToString("0.00");
            distanceText.text = $"{distString} KM";
        }
    }

}
