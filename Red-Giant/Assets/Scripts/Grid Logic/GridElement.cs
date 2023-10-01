using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridElement : MonoBehaviour
{
    public SpriteRenderer icon;

    [SerializeField] private GameObject highlight;
    [SerializeField] private bool highlighted = false;
    private BoxCollider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void SetHighlight(bool status)
    {
        highlight.SetActive(status);
        highlighted = status;
    }

    private void OnMouseEnter()
    {
        SetHighlight(true);
    }

    private void OnMouseExit()
    {
        SetHighlight(false);
    }

    public bool IsHighLighted()
    {
        return highlighted;
    }

    /// <summary>
    /// If a new block enters this cell, highlight it
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NewBlock"))
        {
            SetHighlight(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NewBlock"))
        {
            SetHighlight(false);
            
        }
    }
}

