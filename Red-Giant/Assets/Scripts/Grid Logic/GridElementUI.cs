using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridElementUI : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;

    public bool locked = false;

    [SerializeField] private GameObject highlight;
    [SerializeField] private bool highlighted = false;

    private void SetHighlight(bool status)
    {
        highlight.SetActive(status);
        highlighted = status;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        locked = !locked;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetHighlight(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!locked)
        {
            SetHighlight(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
