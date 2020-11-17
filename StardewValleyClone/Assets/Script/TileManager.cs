using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public static TileManager tileManager;
    public Tilemap GroundTilemap;
    public List<TileData> tileDatas;
    public Dictionary<TileBase, TileData> allTiles;


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
        allTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                allTiles.Add(tile, tileData);
                if (tileData.Name == "Water")
                {
                    GameObject go = new GameObject();
                    go.AddComponent<BoxCollider2D>();
                    //add here
                }
                Debug.Log(tile + " + " + tileData);
                //Debug.Log(GroundTilemap.GetTile(new Vector3Int(0,0,0)));
            }
        }
    }

    //This is a function that will give a quick acess to a corresponding tile postion based on the world postion
    //The reason that I didn't return TileBase itself is that it actually didn't have a getpos() in itself
    //Maybe I should add one for the tiledata later
    public Vector3Int MatchTile(Vector3Int pos)
    {
        //Debug.Log(GroundTilemap.cellBounds);
        //Debug.Log("A "+GroundTilemap.cellBounds.allPositionsWithin);
        //return GroundTilemap.GetTile(GroundTilemap.WorldToCell(pos));

        var tmp_tile = GroundTilemap.GetTile(GroundTilemap.WorldToCell(pos));
        Debug.Log("Seedable " + allTiles[tmp_tile].Seedable);


        return GroundTilemap.WorldToCell(pos);
    }
}
