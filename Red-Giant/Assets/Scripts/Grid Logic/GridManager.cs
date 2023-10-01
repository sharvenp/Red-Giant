using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int height = 5;
    public int width = 5;

    public GameObject GridElement;



    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Create a height x width grid as a child of this game object
    /// </summary>
    private void CreateGrid()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Instantiate(GridElement, new Vector3(i, j), Quaternion.identity, this.transform);
            }
        }
    }
}
