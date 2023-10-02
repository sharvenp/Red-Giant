using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNew : MonoBehaviour
{
    public TetrisItem item;

    public void CreateItem()
    {
        TetrisSlot.instanceSlot.addInFirstSpace(item);
    }
}
