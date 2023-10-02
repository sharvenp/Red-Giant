using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Tetris/Item")]
public class TetrisItem : ScriptableObject
{
    //Parent tree node (parent of all items)

    //Basic information
    public Sprite itemIcon;
    public string itemName;
    public Vector2 itemSize; //x and y

    [SerializeField]
    protected  int att1;
    [SerializeField]
    protected Sprite att1_icon;


   public int getAtt1()
    {
        return att1;

    }

    public Sprite getAtt1Icon()
    {
        return att1_icon;
    }

    public virtual void Use() //to be overrided.
    {
        Debug.Log("using");
    }
}
