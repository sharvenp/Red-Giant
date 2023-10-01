using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int height = 5;
    public int width = 5;

    public GameObject GridElement;
    private GridElement[,] gridElements;


    // Start is called before the first frame update
    void Start()
    {
        gridElements = new GridElement[width, height];
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
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject element = Instantiate(GridElement, new Vector3(i, j), Quaternion.identity, this.transform);
                gridElements[i,j] = element.GetComponent<GridElement>();
            }
        }
    }
}
