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

    public Vector3Int InGridPosition;

    public Vector3Int LocalPlace { get; set; }

    public void SetLocation(int x, int y)
    {
        InGridPosition = new Vector3Int(x, y, 0);
    }

    public void MakeTile()
    {
        GameObject tile_object = new GameObject();
        tile_object.AddComponent<BoxCollider2D>();

        
        
        if (Walkable)
        {
            tile_object.GetComponent<BoxCollider2D>().isTrigger = true;
            if (Seedable)
            { 
                
            }
        }

        if (Fishable)
        {
            //Debug.Log("We now have "+tmp_c+" water tiles");
        }
        //Leaving this as empty, I currently didn't found a way to script individual tiles    
    }

}
