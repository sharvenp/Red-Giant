using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Block : MonoBehaviour
{
    public SpriteRenderer icon;

    [SerializeField] private GameObject highlight;
    [SerializeField] private bool highlighted = false;
    [SerializeField] private bool isDragging = false;
    private Vector2 mouseOffset;

    private void SetHighlight(bool status)
    {
        highlight.SetActive(status);
        highlighted = status;
    }

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

    private void OnMouseEnter()
    {
        if(!isDragging) { 
            SetHighlight(true);
        }
    }

    private void OnMouseExit()
    {
        SetHighlight(false);
    }

    private void OnMouseDown()
    {
        isDragging = true;
        mouseOffset = (Vector2)Camera.main.ScreenToWorldPoint(MousePosition()) - (Vector2)transform.position;
        SetHighlight(false);
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public bool IsHighLighted()
    {
        return highlighted;
    }
}

