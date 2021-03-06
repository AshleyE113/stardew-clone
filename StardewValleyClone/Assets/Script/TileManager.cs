﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public static TileManager tileManager;
    public Tilemap GroundTilemap;
    public List<TileData> tileDatas;
    public Dictionary<TileBase, TileData> allTiles;
    public Vector3 offset;


    private void Awake()
    {
        if (tileManager == null)
        {
            tileManager = this;
        }
        else if (tileManager != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetAllTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This function loads all the tile types into a dictionary
    private void GetAllTiles()
    {
        GroundTilemap.CompressBounds();
        Debug.Log(GroundTilemap.origin);
        allTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                allTiles.Add(tile, tileData);
                //tileData.MakeTile();
                //if (tileData.Name == "Water")
                //{
                    
                //    //GameObject go = new GameObject();
                //    //go.AddComponent<BoxCollider2D>();
                //    //Debug.Log("Generating box collider");
                //    //add here
                //}
                //Debug.Log(tile + " + " + tileData);
                //Debug.Log(GroundTilemap.GetTile(new Vector3Int(0,0,0)));
            }
        }

        foreach (var position in GroundTilemap.cellBounds.allPositionsWithin)
        {
            //Debug.Log(position);
            ////Debug.Log("Hey Imma trying new stuffs, the position is: "+ position + "The tile be: " +GroundTilemap.GetTile(position));
            //GameObject show = new GameObject();
            ////show.AddComponent<TextMeshProUGUI>();
            //show.name = position + "";
            //show.AddComponent<BoxCollider2D>();
            //show.GetComponent<BoxCollider2D>().isTrigger = true;
            //show.transform.position = GroundTilemap.CellToWorld(position) + new Vector3(0.5f, 0.5f, 0);
            ////show.GetComponent<TextMeshProUGUI>().text = "" + position;
            ////show.GetComponent<TextMeshProUGUI>().fontSize = 2;
            ///
            CreateCollisionTile(position);
        }
        Debug.Log(GroundTilemap.size);
    }

    //This is a function that will give a quick acess to a corresponding tile postion based on the world postion
    //The reason that I didn't return TileBase itself is that it actually didn't have a getpos() in itself
    //Maybe I should add one for the tiledata later

    // 
    public TileBase MatchTile(Vector3 Worldpos)
    {
        //Debug.Log(GroundTilemap.cellBounds);
        //Debug.Log("A "+GroundTilemap.cellBounds.allPositionsWithin);
        //return GroundTilemap.GetTile(GroundTilemap.WorldToCell(pos));

        var tmp_tile = GroundTilemap.GetTile(GroundTilemap.WorldToCell(Worldpos));
        Debug.Log("Seedable " + allTiles[tmp_tile].Seedable + " Position: "+ GroundTilemap.WorldToCell(Worldpos));
        return tmp_tile;

        //return GroundTilemap.WorldToCell(pos);
    }

    //This will create an actual game object which contains a boxcollider that resembles the tile size
    public void CreateCollisionTile(Vector3Int position)   //this part affect clicking
    {
        // GameObject box = new GameObject();
        // box.name = position + "";
        // box.AddComponent<BoxCollider2D>();
        // if (CheckTheTile(position, GroundTilemap) != 0)
        // {
        //     //If the tile is not water, player can walk through it
        //     box.GetComponent<BoxCollider2D>().isTrigger = true;
        // }
        // box.transform.position = GroundTilemap.CellToWorld(position) + offset;
    }

    //Check if the tile is collidable
    public int CheckTheTile(Vector3Int position, Tilemap tilemap)
    {
        var tmpTile = tilemap.GetTile(position);
        if (allTiles[tmpTile].Fishable)
        {
            return 0;
        }
        else if (allTiles[tmpTile].Seedable)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
    //Make note here
}
