using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenCamera : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed;

    private void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
