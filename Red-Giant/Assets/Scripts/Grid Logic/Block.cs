using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Block : MonoBehaviour
{
    public SpriteRenderer icon;

    [SerializeField] private bool isDragging = false;
    private Vector2 mouseOffset;

    private Vector3 MousePosition()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 10;
        return mouse;
    }

    private void Update()
    {
        // if you aren't moving this block then don't need to do anything 
        if(isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(MousePosition()) - mouseOffset;
        }

    }

    private void OnMouseDown()
    {
        isDragging = true;
        mouseOffset = (Vector2)Camera.main.ScreenToWorldPoint(MousePosition()) - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}

