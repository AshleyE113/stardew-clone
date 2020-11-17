using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Create new tile")]
public class TileData : ScriptableObject
{
    //This is the list of all the tiles that belong to this tile class
    public TileBase[] tiles;

    //Check the actions that can be done on this tile
    public String Name;
    public Boolean Walkable;
    public Boolean Seedable;
    public Boolean Fishable;

    public Vector3Int LocalPlace { get; set; }



    public void MakeTile()
    {
        if (Walkable)
        {
            GameObject go = new GameObject();
        }
        //Leaving this as empty, I currently didn't found a way to script individual tiles    
    }

}
