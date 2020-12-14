using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Seeds
        //Might addd more later if I have to specify the seed types
    }
    public ItemType itemType;
    public int amount;
}
